// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public abstract class OwnerControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public MapNodeController MapNodeController {get;set;}
    [Inject] public UnitController UnitController {get;set;}
    public abstract void InitializeOwner(OwnerViewModel owner);
    
    public override ViewModel CreateEmpty() {
        return new OwnerViewModel(this);
    }
    
    public virtual OwnerViewModel CreateOwner() {
        return ((OwnerViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeOwner(((OwnerViewModel)(viewModel)));
    }
}

public abstract class MapNodeControllerBase : EntityController {
    
    [Inject] public UnitController UnitController {get;set;}
    [Inject] public MapController MapController {get;set;}
    [Inject] public LinkController LinkController {get;set;}
    [Inject] public OwnerController OwnerController {get;set;}
    public abstract void InitializeMapNode(MapNodeViewModel mapNode);
    
    public override ViewModel CreateEmpty() {
        return new MapNodeViewModel(this);
    }
    
    public virtual MapNodeViewModel CreateMapNode() {
        return ((MapNodeViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializeMapNode(((MapNodeViewModel)(viewModel)));
    }
    
    public virtual void Interact(MapNodeViewModel mapNode, UnitViewModel arg) {
    }
    
    public virtual void UnInteract(MapNodeViewModel mapNode, UnitViewModel arg) {
    }
}

public abstract class CityNodeControllerBase : MapNodeController {
    
    [Inject] public CityCellController CityCellController {get;set;}
    public abstract void InitializeCityNode(CityNodeViewModel cityNode);
    
    public override ViewModel CreateEmpty() {
        return new CityNodeViewModel(this);
    }
    
    public virtual CityNodeViewModel CreateCityNode() {
        return ((CityNodeViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializeCityNode(((CityNodeViewModel)(viewModel)));
    }
    
    public virtual void addUnit(CityNodeViewModel cityNode, UnitViewModel arg) {
    }
}

public abstract class CaveNodeControllerBase : MapNodeController {
    
    public abstract void InitializeCaveNode(CaveNodeViewModel caveNode);
    
    public override ViewModel CreateEmpty() {
        return new CaveNodeViewModel(this);
    }
    
    public virtual CaveNodeViewModel CreateCaveNode() {
        return ((CaveNodeViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializeCaveNode(((CaveNodeViewModel)(viewModel)));
    }
    
    public virtual void addUnit(CaveNodeViewModel caveNode, UnitViewModel arg) {
    }
}

public abstract class UnitControllerBase : EntityController {
    
    [Inject] public MapNodeController MapNodeController {get;set;}
    [Inject] public CityNodeController CityNodeController {get;set;}
    [Inject] public CaveNodeController CaveNodeController {get;set;}
    [Inject] public CityCellController CityCellController {get;set;}
    [Inject] public OwnerController OwnerController {get;set;}
    public abstract void InitializeUnit(UnitViewModel unit);
    
    public override ViewModel CreateEmpty() {
        return new UnitViewModel(this);
    }
    
    public virtual UnitViewModel CreateUnit() {
        return ((UnitViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializeUnit(((UnitViewModel)(viewModel)));
    }
    
    public virtual void GoTo(UnitViewModel unit, MapNodeViewModel arg) {
    }
    
    public virtual void InitUnit(UnitViewModel unit, MapNodeViewModel arg) {
    }
    
    public virtual void UpdateMe(UnitViewModel unit) {
    }
}

public abstract class CityCellControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public CityNodeController CityNodeController {get;set;}
    [Inject] public UnitController UnitController {get;set;}
    public abstract void InitializeCityCell(CityCellViewModel cityCell);
    
    public override ViewModel CreateEmpty() {
        return new CityCellViewModel(this);
    }
    
    public virtual CityCellViewModel CreateCityCell() {
        return ((CityCellViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeCityCell(((CityCellViewModel)(viewModel)));
    }
}

public abstract class EntityControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public ActionController ActionController {get;set;}
    public abstract void InitializeEntity(EntityViewModel entity);
    
    public override ViewModel CreateEmpty() {
        return new EntityViewModel(this);
    }
    
    public virtual EntityViewModel CreateEntity() {
        return ((EntityViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeEntity(((EntityViewModel)(viewModel)));
    }
    
    public virtual void TakeDamage(EntityViewModel entity, Int32 arg) {
    }
    
    public virtual void Command(EntityViewModel entity) {
    }
}

public abstract class MapControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public MapNodeController MapNodeController {get;set;}
    public abstract void InitializeMap(MapViewModel map);
    
    public override ViewModel CreateEmpty() {
        return new MapViewModel(this);
    }
    
    public virtual MapViewModel CreateMap() {
        return ((MapViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeMap(((MapViewModel)(viewModel)));
    }
    
    public virtual void TestCommand(MapViewModel map) {
    }
}

public abstract class ActionControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public EntityController EntityController {get;set;}
    public abstract void InitializeAction(ActionViewModel action);
    
    public override ViewModel CreateEmpty() {
        return new ActionViewModel(this);
    }
    
    public virtual ActionViewModel CreateAction() {
        return ((ActionViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeAction(((ActionViewModel)(viewModel)));
    }
    
    public virtual void Excecute(ActionViewModel action) {
    }
}

public abstract class LinkControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    [Inject] public MapNodeController MapNodeController {get;set;}
    public abstract void InitializeLink(LinkViewModel link);
    
    public override ViewModel CreateEmpty() {
        return new LinkViewModel(this);
    }
    
    public virtual LinkViewModel CreateLink() {
        return ((LinkViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeLink(((LinkViewModel)(viewModel)));
    }
}

public abstract class SettingsControllerBase : Controller {
    
    [Inject("MapInstance")] public MapViewModel MapInstance { get; set; }
    [Inject("GameSettings")] public SettingsViewModel GameSettings { get; set; }
    [Inject("playerOwner")] public OwnerViewModel playerOwner { get; set; }
    public abstract void InitializeSettings(SettingsViewModel settings);
    
    public override ViewModel CreateEmpty() {
        return new SettingsViewModel(this);
    }
    
    public virtual SettingsViewModel CreateSettings() {
        return ((SettingsViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeSettings(((SettingsViewModel)(viewModel)));
    }
}
