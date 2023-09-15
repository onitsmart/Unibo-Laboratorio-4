declare module server {
	interface indexViewModel {
		filtro: string;
		filtroStatoCliente?: any;
		statiCliente: any[];
		clienti: server.clienteInElencoViewModel[];
		totaleElementi: number;
	}
	interface clienteInElencoViewModel {
		urlEdit: string;
		id: string;
		ragioneSocialeONominativo: string;
		ragioneSociale: string;
		indirizzo: string;
		citta: string;
		provincia: string;
		capitaleSociale?: number;
		dataPrimoOrdine?: Date;
		dateDataPrimoOrdineAsString: string;
		stato: any;
	}
}
