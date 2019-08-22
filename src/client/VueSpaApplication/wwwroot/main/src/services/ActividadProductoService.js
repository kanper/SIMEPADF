import AbstractService from './AbstractService'

export default class ActividadProductoService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}actividad/producto`);
    }


    getAll(params) {
        return this.axios.get(`${this.baseUrl.replace('producto','')}${params.id}/producto`)
    }

    add(model, params) {
        return this.axios.post(`${this.baseUrl.replace('producto','')}${params.id}/producto`, model)
    }
}