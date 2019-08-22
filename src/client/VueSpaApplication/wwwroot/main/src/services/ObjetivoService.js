import AbstractService from './AbstractService'

export default class ObjetivoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}objetivo`);
    }

}