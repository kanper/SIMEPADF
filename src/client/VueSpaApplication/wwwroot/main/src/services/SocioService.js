import AbstractService from './AbstractService'

export default class SocioService extends AbstractService{

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}socio-internacional`);
    }
}
