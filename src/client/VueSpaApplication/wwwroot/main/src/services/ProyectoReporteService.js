import AbstractService from './AbstractService'

export default class ProyectoReporteService extends AbstractService {

    constructor(axios, baseUrl) {
        super(axios, `${baseUrl}proyecto/reporte`);
    }
}