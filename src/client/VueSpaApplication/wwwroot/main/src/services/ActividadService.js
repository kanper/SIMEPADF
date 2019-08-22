import AbstractService from './AbstractService'

export default class ActividadService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}actividad`);
    }
}