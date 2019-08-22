import AbstractService from './AbstractService'

export default class ActividadPtService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}plan-trabajo/actividad`);
    }

}