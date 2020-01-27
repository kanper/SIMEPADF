import AbstractService from './AbstractService'

export default class ProyectoSeguimientoRegistroService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto`);
    }

    getAll(idProyecto, idIndicador, quarter) {
        return this.axios.get(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/trimestre/${quarter}/registro`)
    }

    getSocios(id) {
        return this.axios.get(`${this.baseUrl}/${id}/socios`)
    }

    getOrganizaciones(id) {
        return this.axios.get(`${this.baseUrl}/${id}/oraganizaciones`)
    }

    getValor(idProyecto, idIndicador, idDesagregado, idSocio, quarter){
        return this.axios.get(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/trimestre/${quarter}/valor`)
    }

    setValor(idProyecto, idIndicador, idDesagregado, idSocio, valor, quarter){
        return this.axios.put(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/valor/${valor}/trimestre/${quarter}`)
    }

    setValorByPais(idProyecto, idIndicador, idDesagregado, idSocio, valor, pais, quarter){
        return this.axios.put(`${this.baseUrl}/${idProyecto}/seguimiento/${idIndicador}/socio/${idSocio}/desagregado/${idDesagregado}/valor/${valor}/pais/${pais}/trimestre/${quarter}`)
    }

    getProjecCurrentQuarter(idProyecto){
        return this.axios.get(`${this.baseUrl}/${idProyecto}/trimestre`)
    }
}