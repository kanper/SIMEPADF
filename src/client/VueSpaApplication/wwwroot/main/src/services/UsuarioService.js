import AbstractService from './AbstractService'

export default class UsuarioService extends AbstractService {
    authUrl;

    constructor(axios, baseUrl, authUrl) {
        super(axios, `${baseUrl}usuario`);
        this.authUrl = authUrl;
    }

    logout() {
        return this.axios.get(`${this.authUrl}Account/logout`)
    }
}
