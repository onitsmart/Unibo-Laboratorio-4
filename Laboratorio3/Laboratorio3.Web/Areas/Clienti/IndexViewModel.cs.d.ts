declare module server {
	interface indexViewModel {
		filtro: string;
		clienti: server.clienteInElencoViewModel[];
		totaleElementi: number;
	}
	interface clienteInElencoViewModel {
		urlEdit: string;
		id: any;
		ragioneSocialeONominativo: string;
		indirizzo: string;
		comune: string;
		provincia: string;
		capitaleSociale?: number;
		dataPrimoOrdine?: Date;
		dateDataPrimoOrdineAsString: string;
		stato: any;
	}
}
