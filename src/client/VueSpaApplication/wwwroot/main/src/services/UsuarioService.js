import AbstractService from './AbstractService'

export default class UsuarioService extends AbstractService {
    authUrl;

    constructor(axios, baseUrl, authUrl) {
        super(axios, `${baseUrl}usuario`);
        this.authUrl = authUrl;
    }

    logout() {
        return this.axios.post(`${this.authUrl}Account/logout`)
    }
}
