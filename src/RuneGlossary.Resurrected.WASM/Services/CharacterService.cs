using Blazored.LocalStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.WASM.Defaults;
using RuneGlossary.Resurrected.WASM.Models;
using STrain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RuneGlossary.Resurrected.Test.Unit")]
namespace RuneGlossary.Resurrected.WASM.Services
{
    public interface ICharacterService
    {
        IEnumerable<Character> Characters { get; }
        int Index { get; }
        Character? Current { get; }

        event EventHandler<EventArgs> Loaded;
        event EventHandler<EventArgs> Changed;

        Task AddAsync(Character character, CancellationToken cancellationToken);
        Task DeleteAsync(Character character, CancellationToken cancellationToken);
        Task LoadAsync(CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        void Next();
        void Previous();
    }

    public class CharacterService(ILocalStorageService storage, IRequestSender sender) : ICharacterService
    {
        private const string KEY = "characters";

        private IEnumerable<GetItemTypesQuery.Result> _itemTypes = [];

        private readonly ILocalStorageService _storage = storage;
        private readonly IRequestSender _sender = sender;

        private ICollection<Character> _characters = [];
        public IEnumerable<Character> Characters => _characters;

        public int Index { get; private set; } = 0;
        public Character? Current => _characters.ElementAtOrDefault(Index);

        public event EventHandler<EventArgs>? Loaded;
        public event EventHandler<EventArgs>? Changed;

        public async Task LoadAsync(CancellationToken cancellationToken)
        {
            _itemTypes = await _sender.GetAsync<GetItemTypesQuery, IEnumerable<GetItemTypesQuery.Result>>(new GetItemTypesQuery(), cancellationToken) ?? [];

            var raw = await _storage.GetItemAsStringAsync(KEY, cancellationToken);
            if (!string.IsNullOrWhiteSpace(raw))
            {
                var data = JsonConvert.DeserializeObject<IEnumerable<Data>>(raw, new JsonSerializerSettings
                {
                    Converters = [new StringEnumConverter()]
                }) ?? [];
                _characters = [.. data.Select(d => new Character
                {
                    Name = d.Name,
                    Class = d.Class,
                    Level = d.Level,
                    Filters = new FilterData
                    {
                        ItemTypes = _itemTypes!.Select(it => new ItemType { Id = it.Id, Class = it.Class, Name = it.Name, Selected = d.Filters.Contains(it.Id) }).ToList()
                    }
                })];
            }

            foreach (var character in _characters)
            {
                character.PropertyChanged += (_, __) => Changed?.Invoke(this, EventArgs.Empty);

                foreach (var filter in character.Filters.ItemTypes)
                {
                    filter.PropertyChanged += (_, __) => Changed?.Invoke(this, EventArgs.Empty);
                }
            }

            Loaded?.Invoke(this, EventArgs.Empty);
        }

        public void Next()
        {
            if (Index == _characters.Count - 1) return;
            Index++;

            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Previous()
        {
            if (Index == 0) return;
            Index--;

            Changed?.Invoke(this, EventArgs.Empty);
        }

        public async Task AddAsync(Character character, CancellationToken cancellationToken)
        {
            character.Filters = new FilterData
            {
                ItemTypes = _itemTypes.GetDefaultFilters(character.Class)
            };
            _characters.Add(character);
            NavigateTo(_characters.Count - 1);

            await SaveAsync(cancellationToken);
        }

        private void NavigateTo(int index)
        {
            Index = index;
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public async Task DeleteAsync(Character character, CancellationToken cancellationToken)
        {
            _characters.Remove(character);
            NavigateTo(Index == _characters.Count ? --Index : Index);
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _storage.SetItemAsync(KEY, _characters.Select(c => new Data
            {
                Name = c.Name,
                Level = c.Level,
                Class = c.Class,
                Filters = c.Filters.ItemTypes.Where(f => f.Selected).Select(f => f.Id).ToList()
            }).ToList(), cancellationToken);
        }
    }

    file sealed record Data
    {
        public required string Name { get; init; }
        public required Class Class { get; init; }
        public required int Level { get; set; }
        public required IEnumerable<int> Filters { get; set; }
    }

    file static class CharacterServiceExtensions
    {
        public static IEnumerable<ItemType> GetDefaultFilters(this IEnumerable<GetItemTypesQuery.Result> filters, Class @class)
        {
            var result = filters.Select(it => new ItemType { Id = it.Id, Name = it.Name, Class = it.Class, Selected = false }).ToList();
            var selected = filters.Select(it => it.Id).ToList();
            switch (@class)
            {
                case Class.Amazon:
                    selected = ClassDefaults.Filters.Amazon.ToList();
                    break;
                case Class.Assassin:
                    selected = ClassDefaults.Filters.Assassin.ToList();
                    break;
                case Class.Barbarian:
                    selected = ClassDefaults.Filters.Barbarian.ToList();
                    break;
                case Class.Druid:
                    selected = ClassDefaults.Filters.Druid.ToList();
                    break;
                case Class.Necromancer:
                    selected = ClassDefaults.Filters.Necromancer.ToList();
                    break;
                case Class.Paladin:
                    selected = ClassDefaults.Filters.Paladin.ToList();
                    break;
                case Class.Sorceress:
                    selected = ClassDefaults.Filters.Sorceress.ToList();
                    break;
            }

            foreach (var id in selected)
            {
                result.SingleOrDefault(it => it.Id == id)!.Selected = true;
            }

            return result;
        }
    }
}
