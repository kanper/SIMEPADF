import AbstractService from './AbstractService'

export default class SeguimientoIndicadorService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}seguimiento/indicadores/`);
    }

    seguimientoDesagregados(year, quarter) {
        return this.axios.get(`${this.baseUrl}desagregados/anio/${year}/trimestre/${quarter}`);
    }
}