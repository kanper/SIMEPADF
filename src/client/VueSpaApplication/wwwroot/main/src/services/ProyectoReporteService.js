import AbstractService from './AbstractService'

export default class ProyectoReporteService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto/reporte`);
    }

    getAll(params) {
        return this.axios.get(`${this.baseUrl}/anio/${params.year}/trimestre/${params.quarter}/paises/${params.countries}/socios/${params.socios}`)
    }
}