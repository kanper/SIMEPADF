import AbstractService from './AbstractService'

export default class ProductoEvidenciaService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios, `${baseUrl}actividad`)
    }       

    get(id, params) {
        return this.axios.get(`${this.baseUrl}/producto/${id}/evidencia`)
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/${params.id}/producto/evidencia`)
    }

    upload(id, model){
        return this.axios.post(`${this.baseUrl}/${id}/producto/evidencia`,model)
    }
}