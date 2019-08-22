import AbstractService from './AbstractService'

export default class FuenteDatoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}fuente-dato`);
    }
}