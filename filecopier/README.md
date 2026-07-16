# FileCopier

Applicazione Windows in C# per copiare file tramite interfaccia grafica Windows Forms, con gestione degli errori e sovrascrittura sicura dei file esistenti.

## Funzionalità

- Selezione del file tramite `OpenFileDialog`
- Scelta della cartella di destinazione tramite `FolderBrowserDialog`
- Copia del file con `File.Copy` e sovrascrittura automatica
- Gestione specifica delle eccezioni:
  - permessi insufficienti
  - file aperto da un altro programma
  - errori di I/O
  - errori imprevisti
- Console mantenuta aperta al termine dell'operazione

## Come funziona

1. L'utente seleziona il file che vuole copiare tramite una finestra di dialogo Windows.
2. L'applicazione richiede la scelta della cartella di destinazione.
3. Il file viene copiato nella posizione scelta, sostituendo eventuali file con lo stesso nome.
4. Al termine dell'operazione il programma mostra il risultato e rimane aperto in attesa di un input.

## Build ed esecuzione

```bash
dotnet build
dotnet run
```
