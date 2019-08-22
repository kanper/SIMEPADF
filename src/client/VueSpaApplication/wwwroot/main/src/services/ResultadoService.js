import AbstractService from './AbstractService'

export default class ResultadoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}resultado`);
    }

}