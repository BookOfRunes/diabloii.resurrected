function idToken() {
    var value = sessionStorage.getItem('oidc.user:https://login.microsoftonline.com/3e56baf4-8b33-4eac-abc7-fe892bc17c68/:5c9c6c64-fe40-4a24-a68d-30907d7178c0')
    if (value == null) return null;

    return JSON.parse(value).id_token;
}