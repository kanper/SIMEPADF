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

    download(id){
        window.open(`${this.baseUrl}/producto/${id}/archivo/download`)
    }

    getFile(id){
        return this.axios.get(`${this.baseUrl}/producto/${id}/archivo/info`)
    }

    updateFile(id, model){
        this.axios.put(`${this.baseUrl}/producto/${id}/archivo/info`,model)
    }

    remove(id, params){
        return this.axios.delete(`${this.baseUrl}/producto/${id}/archivo/remove`)
    }

    executeAction(id, action, params) {
        console.log("In swith");
        switch(action){
            case 'download':                
                return this.download(id);
                break;                
            default:
                return null;
        }
    }
}