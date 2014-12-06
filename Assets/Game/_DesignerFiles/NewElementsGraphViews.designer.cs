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
using UnityEngine;
using UniRx;


[DiagramInfoAttribute("Game")]
public abstract class OwnerViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Vector3 _color;
    
    public override System.Type ViewModelType {
        get {
            return typeof(OwnerViewModel);
        }
    }
    
    public OwnerViewModel Owner {
        get {
            return ((OwnerViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<OwnerController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        OwnerViewModel owner = ((OwnerViewModel)(viewModel));
        owner.color = this._color;
    }
}

[DiagramInfoAttribute("Game")]
public abstract class MapNodeViewBase : EntityViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _owner;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Boolean _isVisible;
    
    public override System.Type ViewModelType {
        get {
            return typeof(MapNodeViewModel);
        }
    }
    
    public MapNodeViewModel MapNode {
        get {
            return ((MapNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<MapNodeController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        MapNodeViewModel mapNode = ((MapNodeViewModel)(viewModel));
        mapNode.owner = this._owner == null ? null : this._owner.ViewModelObject as OwnerViewModel;
        mapNode.isVisible = this._isVisible;
    }
}

[DiagramInfoAttribute("Game")]
public abstract class CityNodeViewBase : MapNodeViewBase {
    
    public override System.Type ViewModelType {
        get {
            return typeof(CityNodeViewModel);
        }
    }
    
    public CityNodeViewModel CityNode {
        get {
            return ((CityNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CityNodeController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
    }
}

[DiagramInfoAttribute("Game")]
public abstract class CaveNodeViewBase : MapNodeViewBase {
    
    public override System.Type ViewModelType {
        get {
            return typeof(CaveNodeViewModel);
        }
    }
    
    public CaveNodeViewModel CaveNode {
        get {
            return ((CaveNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CaveNodeController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
    }
}

[DiagramInfoAttribute("Game")]
public abstract class UnitViewBase : EntityViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _owner;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public UnitState _state;
    
    public override System.Type ViewModelType {
        get {
            return typeof(UnitViewModel);
        }
    }
    
    public UnitViewModel Unit {
        get {
            return ((UnitViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<UnitController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        UnitViewModel unit = ((UnitViewModel)(viewModel));
        unit.owner = this._owner == null ? null : this._owner.ViewModelObject as OwnerViewModel;
        unit.state = this._state;
    }
}

[DiagramInfoAttribute("Game")]
public abstract class CityCellViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _unit;
    
    public override System.Type ViewModelType {
        get {
            return typeof(CityCellViewModel);
        }
    }
    
    public CityCellViewModel CityCell {
        get {
            return ((CityCellViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CityCellController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        CityCellViewModel cityCell = ((CityCellViewModel)(viewModel));
        cityCell.unit = this._unit == null ? null : this._unit.ViewModelObject as UnitViewModel;
    }
}

[DiagramInfoAttribute("Game")]
public abstract class EntityViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _attack;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _defence;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _attackDelay;
    
    public override System.Type ViewModelType {
        get {
            return typeof(EntityViewModel);
        }
    }
    
    public EntityViewModel Entity {
        get {
            return ((EntityViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<EntityController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        EntityViewModel entity = ((EntityViewModel)(viewModel));
        entity.attack = this._attack;
        entity.defence = this._defence;
        entity.attackDelay = this._attackDelay == null ? null : this._attackDelay.ViewModelObject as ActionViewModel;
    }
    
    public virtual void ExecuteTakeDamage(Int32 arg) {
        this.ExecuteCommand(Entity.TakeDamage, arg);
    }
}

[DiagramInfoAttribute("Game")]
public abstract class MapViewBase : ViewBase {
    
    public override string DefaultIdentifier {
        get {
            return "MapInstance";
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(MapViewModel);
        }
    }
    
    public MapViewModel Map {
        get {
            return ((MapViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<MapController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
    }
}

[DiagramInfoAttribute("Game")]
public abstract class ActionViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Single _delay;
    
    public override System.Type ViewModelType {
        get {
            return typeof(ActionViewModel);
        }
    }
    
    public ActionViewModel Action {
        get {
            return ((ActionViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<ActionController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        ActionViewModel action = ((ActionViewModel)(viewModel));
        action.delay = this._delay;
    }
    
    public virtual void ExecuteExcecute() {
        this.ExecuteCommand(Action.Excecute);
    }
}

[DiagramInfoAttribute("Game")]
public abstract class LinkViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _node1;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _node2;
    
    public override System.Type ViewModelType {
        get {
            return typeof(LinkViewModel);
        }
    }
    
    public LinkViewModel Link {
        get {
            return ((LinkViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<LinkController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        LinkViewModel link = ((LinkViewModel)(viewModel));
        link.node1 = this._node1 == null ? null : this._node1.ViewModelObject as MapNodeViewModel;
        link.node2 = this._node2 == null ? null : this._node2.ViewModelObject as MapNodeViewModel;
    }
}

[DiagramInfoAttribute("Game")]
public abstract class SettingsViewBase : ViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Single _speed;
    
    public override string DefaultIdentifier {
        get {
            return "GameSettings";
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(SettingsViewModel);
        }
    }
    
    public SettingsViewModel Settings {
        get {
            return ((SettingsViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<SettingsController>());
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        SettingsViewModel settings = ((SettingsViewModel)(viewModel));
        settings.speed = this._speed;
    }
}

public class CityNodeViewViewBase : CityNodeViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CityNodeController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class CityNodeView : CityNodeViewViewBase {
}

public class SettingsViewViewBase : SettingsViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<SettingsController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class SettingsView : SettingsViewViewBase {
}

public class MapViewViewBase : MapViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<MapController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class MapView : MapViewViewBase {
}

public class LinkViewViewBase : LinkViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<LinkController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class LinkView : LinkViewViewBase {
}

public class UnitViewViewBase : UnitViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<UnitController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class UnitView : UnitViewViewBase {
}
