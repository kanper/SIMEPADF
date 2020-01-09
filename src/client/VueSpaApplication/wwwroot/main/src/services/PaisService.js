import AbstractService from './AbstractService'

export default class PaisService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}pais`);
    }

}
