import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-calculator-component',
  templateUrl: './calculator.component.html',
})
export class CalculatorComponent {

  readonly defaultStyle: string = "DefaultDialogStyle";
  readonly altStyle: string = "AltDialogStyle";
  styleToUse: string = this.defaultStyle;

  constructor(public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(CalculatorComponentDialog, {
      width: '750px',
      data: { style: this.styleToUse },
      panelClass: this.styleToUse
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  toggleCalculatorStyle(): void {
    // Toggle between the 2 styles based on the currently selected class.
    this.styleToUse = this.styleToUse === this.defaultStyle ? this.altStyle : this.defaultStyle;
  }
}


@Component({
  selector: 'app-calculator-dialog',
  templateUrl: './calculator.component-dialog.html'
})
export class CalculatorComponentDialog {
  //@Output() closeModalEvent = new EventEmitter();

  display: string | null = null;
  firstValue: number | null = null;
  action: string | null = null;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public dialogRef: MatDialogRef<CalculatorComponentDialog>) {

  }

  Operation(op: string): void {
    if (this.display !== null) {
      this.firstValue = Number(this.display);
      this.action = op;
      this.display = null;
    }
  }

  Calculate(): void {
    let endpoint = "";

    switch (this.action) {
      case "+": {
        endpoint = "Add"
        break;
      }
      case "-": {
        endpoint = "Subtract"
        break;
      }
      default:
        {
          //Log what the supposed action is that hasn't been implemented.
          console.log("Unknown action: " + this.action);
          break;
        }

    }

    //Make sure we have an operation to perform. Make sure firstvalue has a value to supress an error. 
    if (endpoint !== "" && this.firstValue !== null) {
      let params = new HttpParams().set("start", this.firstValue)
        .append("amount", Number(this.display));

      this.http.get<any>(this.baseUrl + 'SimpleCalculator/' + endpoint, { params })
        .subscribe((response: number) => {
          //on success set the first value and display to the response, clear out action
          this.firstValue = response;
          this.display = String(response);
          this.action = null;
        }, error => {
          //Handle the error / show some user appropriate message (probably not telling them to check the console).
          console.log(error);
          alert("A Problem has occured. Please check console for details.");
          this.Clear();
        });
    }
  }

  Clear(): void {
    this.firstValue = null;
    this.display = null;
    this.action = null;
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
