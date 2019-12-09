import AbstractService from './AbstractService'

export default class ProyectoSeguimientoRegistroService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(idProyecto, idIndicador) {
        return this.axios.get(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/registro`)
    }

    getSocios(id) {
        return this.axios.get(`${this.baseUrl}/${id}/socios`)
    }

    getOrganizaciones(id) {
        return this.axios.get(`${this.baseUrl}/${id}/oraganizaciones`)
    }

    getValor(idProyecto, idIndicador, idDesagregado, idSocio){
        return this.axios.get(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/valor`)
    }

    setValor(idProyecto, idIndicador, idDesagregado, idSocio, valor){
        return this.axios.put(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/valor/${valor}`)
    }

    setValorByPais(idProyecto, idIndicador, idDesagregado, idSocio, valor, pais){
        return this.axios.put(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/valor/${valor}/pais/${pais}`)
    }
}