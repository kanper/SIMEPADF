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

    getCodigoSocios(){
        return this.axios.get(`${this.baseUrl}/socios/codigos`)
    }

    getDesagregados(){
        return this.axios.get(`${this.baseUrl}/desagregados`)
    }
}