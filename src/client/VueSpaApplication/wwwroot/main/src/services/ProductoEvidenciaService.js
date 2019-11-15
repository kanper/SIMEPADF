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
        return this.axios.post(`${this.baseUrl}/producto/${id}/archivo/upload`,model,
        {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        })
    }

    download(id, fileName){
        window.open(`${this.baseUrl}/producto/${id}/archivo/download/${fileName}`)
    }

    getFile(id){
        return this.axios.get(`${this.baseUrl}/producto/${id}/archivo/info`)
    }

    updateFile(id, model){
        return this.axios.put(`${this.baseUrl}/producto/${id}/archivo/update`,model)
    }

    remove(id, params){
        return this.axios.delete(`${this.baseUrl}/producto/${id}/archivo/remove`)
    }

}