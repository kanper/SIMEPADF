import AbstractService from './AbstractService'

export default class SeguimientoIndicadorService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}seguimiento/indicadores/`);
    }

    seguimientoDesagregados(start, end) {
        return this.axios.get(`${this.baseUrl}desagregados/inicio/${start}/fin/${end}`);
    }

    seguimientoPais(year, quarter) {
        return this.axios.get(`${this.baseUrl}pais/anio/${year}/trimestre/${quarter}`);
    }

    seguimientoRegion(year, quarter) {
        return this.axios.get(`${this.baseUrl}region/anio/${year}`);
    }
}