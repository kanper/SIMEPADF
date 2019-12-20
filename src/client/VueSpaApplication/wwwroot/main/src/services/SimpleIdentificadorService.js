import AbstractService from './AbstractService'

export default class SimpleIdentificadorService extends AbstractService {

    constructor(axios, baseUrl){
        super(axios, `${baseUrl}identificador`);
    }

    getProyecto(id){
        return this.axios.get(`${this.baseUrl}/proyecto/${id}`)
    }

    getActividadPT(id){
        return this.axios.get(`${this.baseUrl}/actividad-pt/${id}`)
    }

    getIndicador(id){
        return this.axios.get(`${this.baseUrl}/indicador/${id}`)
    }

    getCodigoPaises(){
        return this.axios.get(`${this.baseUrl}/paises/codigos`)
    }

    getPaises() {
        return this.axios.get(`${this.baseUrl}/paises`)
    }

    getCodigoSocios(){
        return this.axios.get(`${this.baseUrl}/socios/codigos`)
    }

    getSocios(){
        return this.axios.get(`${this.baseUrl}/socios`)
    }

    getDesagregados(){
        return this.axios.get(`${this.baseUrl}/desagregados`)
    }
}