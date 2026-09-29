# Gestione Flotta Veicoli - Noleggio Auto

## Problema
Un'azienda di noleggio auto ha bisogno di un modulo per la gestione dei veicoli della propria flotta. 
Ogni veicolo è caratterizzato da:

- Un identificativo unico (Id)

- Una targa (LicensePlate)

- Il chilometraggio attuale (OdometerKm)

- La tariffa giornaliera di noleggio (DailyRate)

- Il livello percentuale di carburante nel serbatoio (FuelLevelPercentage)

L'azienda desidera un modello solido che:

- Impedisca la creazione di veicoli o valori incoerenti (es. targa non valida, chilometri o tariffe negative).

- Permetta di registrare i viaggi effettuati, incrementando il chilometraggio e riducendo il carburante residuo.

- Consenta di effettuare il rifornimento fino a un massimo del 100% della capienza del serbatoio.

- Fornisca metodi di utilità sintetici ed espressivi per formattare le informazioni ed evidenziare situazioni d'allarme (es. riserva carburante).