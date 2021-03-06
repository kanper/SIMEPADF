import AbstractService from './AbstractService'

export default class ProyectoReporteService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto/reporte`);
    }

    getReporte(id, startDate, endDate) {
        return this.axios.get(`${this.baseUrl}/id/${id}/start/${startDate}/end/${endDate}`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/anio/${params.year}/paises/${params.countries}/socios/${params.socios}`)
    }
}