import { Component } from '@angular/core';
import { Http } from '@angular/http';

declare var Stimulsoft: any;

@Component({
    selector: 'app',
    templateUrl: './stimulsoft.component.html',
    styleUrls: ['./stimulsoft.component.css']
})
export class StimulsoftComponent {
    options: any;
    viewer: any;

    ngOnInit() {
        console.log('Loading Viewer view');

        this.options = new Stimulsoft.Viewer.StiViewerOptions();
        // Setting the required options on the client side
        //this.options.toolbar.showPrintButton = false;
        //this.options.appearance.scrollbarsMode = true;
        //this.options.height = "600px";

        this.viewer = new Stimulsoft.Viewer.StiViewer(this.options, 'StiViewer', false);
        this.viewer.renderHtml('viewer');
    }

    constructor(private http: Http) {
    }
}
