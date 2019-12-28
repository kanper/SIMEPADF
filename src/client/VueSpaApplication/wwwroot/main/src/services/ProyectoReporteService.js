import AbstractService from './AbstractService'

export default class ProyectoReporteService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto/reporte`);
    }

    getReporte(id, quarter, year) {
        return this.axios.get(`${this.baseUrl}/id/${id}/anio/${year}/trimestre/${quarter}`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/anio/${params.year}/paises/${params.countries}/socios/${params.socios}`)
    }
}