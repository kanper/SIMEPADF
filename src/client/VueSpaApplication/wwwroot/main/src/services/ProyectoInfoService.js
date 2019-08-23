import AbstractService from './AbstractService'

export default class ProyectoInfoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto-info`);
    }


    getAll(params) {
        return this.axios.get(`${this.baseUrl}/${params.id}/all`)
    }
}