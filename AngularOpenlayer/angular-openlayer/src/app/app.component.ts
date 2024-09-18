import { Component,ViewChild,VERSION,ElementRef, OnInit, Input, TemplateRef, Injectable, inject, AfterViewInit } from '@angular/core';
import  Map from 'ol/Map';
import { ModalDismissReasons, NgbAccordionModule, NgbModal, NgbModalConfig, NgbModalRef, NgbOffcanvasModule } from '@ng-bootstrap/ng-bootstrap';
import { Form ,ControlValueAccessor} from '@angular/forms';
import { Subscription, catchError, lastValueFrom, map, subscribeOn } from 'rxjs';
import { AppModule } from './app.module';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AnyType } from 'ol/expr/expression';
import VectorSource from 'ol/source/Vector';
import VectorLayer from 'ol/layer/Vector';
import { View ,Feature, Observable} from 'ol';
import { Projection, fromLonLat } from 'ol/proj';
import Tile from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { click, noModifierKeys,primaryAction} from 'ol/events/condition';
import olDrawEvent  from 'ol/interaction/Draw'
import { defaults as defaultInteractions,Draw, Select} from 'ol/Interaction';
import { HttpClient, HttpErrorResponse, HttpHeaderResponse } from '@angular/common/http';
import { HttpClientService } from 'src/app/http-client.service';
import * as myGlobals from 'globals';
import { FormGroup } from '@angular/forms';
import { FeatureObject } from 'ol/format/Feature';
import GetSource from 'ol/source/Source';
import WKT from 'ol/format/WKT'
import { geometrys  } from './geometrys';
import { format } from 'ol/coordinate';
import { toPromise } from 'ol/functions';
import {  Geometry, Point, Polygon, SimpleGeometry } from 'ol/geom';
import { toInteger } from '@ng-bootstrap/ng-bootstrap/util/util';
import { extendCoordinates } from 'ol/extent';
import { SelectEvent } from 'ol/interaction/Select';
import { set } from 'ol/transform';
import { getCurrencySymbol } from '@angular/common';
import Style from 'ol/style/Style';
import Text from 'ol/style/Text';
import Fill from 'ol/style/Fill';
import Stroke from 'ol/style/Stroke';
import Circle from 'ol/style/Circle';
import { style } from '@angular/animations';
import { circular } from 'ol/geom/Polygon';
import { NgForm } from '@angular/forms';
import TextFeature from 'ol/format/TextFeature';
import { toFeature } from 'ol/render/Feature';
let select=new Select({});
declare var $:any
let ö:any;
let den=null;
let texter:any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title=""

}



