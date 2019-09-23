import AbstractService from './AbstractService'

export default class ProyectoFinalizedService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/estado/${params.status}`);
    }
}