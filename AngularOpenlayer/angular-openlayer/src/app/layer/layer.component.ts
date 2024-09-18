import { Component,ViewChild,VERSION,ElementRef, OnInit, Input, TemplateRef, Injectable, inject, AfterViewInit } from '@angular/core';
import  Map from 'ol/Map';
import { ModalDismissReasons, NgbAccordionModule, NgbModal, NgbModalConfig, NgbModalRef, NgbOffcanvasModule } from '@ng-bootstrap/ng-bootstrap';
import { Form ,ControlValueAccessor} from '@angular/forms';
import { Subscription, catchError, lastValueFrom, map, subscribeOn } from 'rxjs';
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
import { geometrys } from 'src/app/geometrys';
let select=new Select({});
declare var $:any
let ö:any;
let den=null;
let texter:any;
@Component({
  selector: 'app-layer',
  templateUrl: './layer.component.html',
  styleUrls: ['./layer.component.scss']
})
export class LayerComponent implements OnInit, AfterViewInit {
  title="s";
  map:any;
  a:any;
  draw:any;
 
  datas:any;
  NameModal:any;
  SurNameModal:any;
  CommentModal:any;
  DateModal:any;
  gnclGeo:any;
 de:any;
 hop:any;
constructor(private httpClientService:HttpClientService){}

  @ViewChild("types",{static:true,read:ElementRef}) types:any;
  @ViewChild('myModal', { static: false }) myModal: ElementRef;
  @ViewChild('gnclModal', { static: false }) gnclModal: ElementRef;
  elm: HTMLElement;
  gnclelm:HTMLElement;
  ngAfterViewInit(): void {
     this.elm = this.myModal.nativeElement as HTMLElement;
     this.gnclelm=this.gnclModal.nativeElement as HTMLElement;
     this.initilizeMap();
     this.a=this.types.nativeElement.value;
     this.onChange;
     this.drawAdd();
     this.getAll();
   this.selection();  
  }
 
  open(): void {
      this.elm.classList.add('show');
      this.elm.style.width = '100vw';
       }
  Gnclopen() {
    this.gnclelm.classList.add('show');
    this.gnclelm.style.width = '100vw';
   }
  
Gnclclose(): void {
   select.getFeatures().clear();
  this.gnclelm.classList.remove('show');
 
  setTimeout(() => {
    this.gnclelm.style.width = '0';
  }, 75);
}
  close(): void {
    
    this.elm.classList.remove('show');
    setTimeout(() => {
      this.elm.style.width = '0';
    }, 75);
}
ngOnInit(): void {
}

  vectorSource=new VectorSource();
  vectorLayer=new VectorLayer({
    source :this.vectorSource,
    style:function(feature){
      return[
        new Style({
          fill:new Fill({
            color:'rgba(255,255,255,0.4)'
          }),stroke:new Stroke({
            color: '#3399CC',
            width: 1.25
          }),text:new Text({
            font: '15px Calibri,sans-serif',
            fill:new Fill({
              color: '#000'
            }),stroke:new Stroke({color: '#fff', width: 2}),
            text:feature.getProperties()['name']
          })
        }),new Style({
          image:new Circle({
          radius:25,
          fill:new Fill({
            color:'rgba(255,255,255,0.4)',
          
          }),stroke:new Stroke({
            color: '#3399CC',
            width: 1.25
          }),
        })
         
        })
      ]
    }
      
    
  });
  raster=new Tile({
    source: new OSM
  })
typ(){
  if (this.a=="none") {
    
    select.setActive(true);
  }else{
    select.setActive(false);
  }
}
  onChange(e:any){
  
    this.a=(e.target as HTMLSelectElement)?.value;
    this.map.removeInteraction(this.draw);
    this.drawAdd();
    console.log(this.a);
    this.typ();
  }
  initilizeMap(){
    this.map=new Map({
      target:'map',
      layers:[this.raster,this.vectorLayer ],
      controls:[],
      view:new View({
        center:fromLonLat([0,1]),
          zoom:4,
    
          
      })
    });
    
    }
  
  drawAdd(){
  if(this.a!='none'){
    this.draw=new Draw({
      source: this.vectorSource,
      type:this.a,
      condition:(e)=>noModifierKeys(e) && primaryAction(e)
    })
    this.map.addInteraction(this.draw);
    this.draw.on('drawend',(e:olDrawEvent)=>{
       this.open();
     })
    
  }
}
btnClose(){
  
this.close();
this.refresh();
}
refresh(){
  debugger;
  var featuress=this.vectorSource.getFeatures();
  var lastfeature=featuress[featuress.length-1];
  this.vectorSource.removeFeature(lastfeature);
}
 b:any;
 c:any;
 d:any;
@ViewChild("isim",{static:true,read:ElementRef}) isim:any;
@ViewChild("soyisim",{static:true,read:ElementRef}) soyisim:any;
@ViewChild("yorum",{static:true,read:ElementRef}) yorum:any;

deneme:any;
getAll(){
  
  this.httpClientService.get<geometrys[]>({
    fullEndPoint:"https://localhost:7173/api/geometry"
    }).subscribe(data=>{
      
      for (let index = 0; index < data.length; index++) {
      
      var namer,commenter,ider,surnamer,dater,geo;
       geo=data[index].geom;
       namer=data[index].namew;
       ider=data[index].id;
       commenter=data[index].commentw;
       surnamer=data[index].surnamew;
       dater=data[index].datew;
      const format=new WKT();
       var ba=format.readFeature(geo);
      const av=ba.getGeometry();
        debugger;
        if(av instanceof SimpleGeometry){
          this.de=av.getCoordinates();
        }
        const chose=this.de.at().length;
        if(chose>2){
          let pol=new Polygon(this.de);
          this.vectorSource.addFeature(new Feature({id:ider,geometry:pol,name:namer,date:dater,comment:commenter,surname:surnamer}));
        }else{
          let pot=new Point(this.de);
          this.vectorSource.addFeature(new Feature({id:ider,geometry:pot,name:namer,date:dater,comment:commenter,surname:surnamer}));
        }      
      }
    });
    return;
}



btnSave(){
  var featureList=this.vectorLayer.getSource().getFeatures();
  var s = featureList.length;
  var ilkEleman = featureList[s - 1];
  if (ilkEleman) {
      var wkb = new WKT();
      var wkbFeature = wkb.writeFeature(ilkEleman);
  }
 
  this.b=this.isim.nativeElement.value;
  this.c=this.soyisim.nativeElement.value;
  this.d=this.yorum.nativeElement.value;
  if(this.b!==""&&this.c!==""&&this.d!==""){
    this.httpClientService.post({
      fullEndPoint:"https://localhost:7173/api/geometry",
      action:"post",
      },{
      Namew:this.b,
      Surnamew:this.c,
      Commentw:this.d,
      Geom:wkbFeature,
    }).subscribe(data=>{
      this.close();
      this.getAll();
      alert("Yeni Kayıt Başarılı!!!")
    });
  }else{
    alert("Bütün Alanları Doldurunuz!!!")
  }
}


selection():void{
  
  this.map.addInteraction(select);
 select.on('select',(events)=>{
  
  
var ss=events.selected.length;
var d=events.selected[0].getProperties();
den=events.selected[0].getProperties()['id'];
this.gnclGeo=events.selected[0].getProperties()['id'];
for (let index = 0; index < ss; index++) {
  this.CommentModal=d['comment'];
  this.DateModal=d['date'];
  this.NameModal=d['name'];
  this.SurNameModal=d['surname']
 this.Gnclopen();
 console.log(den)
}
})

}

btnDelete(){
 var denemeler=den;
  console.log(denemeler);
  this.httpClientService.delete(den).subscribe(data=>{
    this.vectorSource.clear();  
    this.getAll();
    alert("Kayıt Başarıyla Silindi!!!")
   });
this.Gnclclose();
}
e:any;
f:any;
g:any;
@ViewChild("Gname",{static:true,read:ElementRef}) gnclisim:any;
@ViewChild("Gsurname",{static:true,read:ElementRef}) gnclsoyisim:any;
@ViewChild("Gcomment",{static:true,read:ElementRef}) gnclyorum:any;
 
btnChange(){
  
  
  this.e=this.gnclisim.nativeElement.value;
  this.f=this.gnclsoyisim.nativeElement.value;
  this.g=this.gnclyorum.nativeElement.value;
  den;
  if(this.e!==""&&this.f!==""&&this.g!==""){
this.httpClientService.put({
  fullEndPoint:"https://localhost:7173/api/geometry",
  action:"put"
},{
      Namew:this.e,
      Surnamew:this.f,
      Commentw:this.g,
      id:den,
}).subscribe(data=>{
  this.vectorSource.clear();
  this.getAll();
  this.Gnclclose();
  alert("Kayıtlar Güncellendi!!!")
});
}else{
  alert("Bütün Alanları Doldurunuz!!!")
}

 }

}
