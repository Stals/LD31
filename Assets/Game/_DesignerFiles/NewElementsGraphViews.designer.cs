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
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _money;
    
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
        owner.money = this._money;
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
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _maxCells;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _GoldPerTIck;
    
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
        CityNodeViewModel cityNode = ((CityNodeViewModel)(viewModel));
        cityNode.maxCells = this._maxCells;
        cityNode.GoldPerTIck = this._GoldPerTIck;
    }
    
    public virtual void ExecuteaddUnit(UnitViewModel unit) {
        this.ExecuteCommand(CityNode.addUnit, unit);
    }
}

[DiagramInfoAttribute("Game")]
public abstract class CaveNodeViewBase : MapNodeViewBase {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _goldLevel;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _attackLevel;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _defenseLevel;
    
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
        CaveNodeViewModel caveNode = ((CaveNodeViewModel)(viewModel));
        caveNode.goldLevel = this._goldLevel;
        caveNode.attackLevel = this._attackLevel;
        caveNode.defenseLevel = this._defenseLevel;
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
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _currentMapNode;
    
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
        unit.currentMapNode = this._currentMapNode == null ? null : this._currentMapNode.ViewModelObject as MapNodeViewModel;
    }
    
    public virtual void ExecuteGoTo(MapNodeViewModel mapNode) {
        this.ExecuteCommand(Unit.GoTo, mapNode);
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
    
    public virtual void ExecuteTestCommand() {
        this.ExecuteCommand(Map.TestCommand);
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

public class CityNodeViewViewBase : MapNodeView {
    
    [UFToggleGroup("maxCells")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("maxCellsChanged")]
    public bool _BindmaxCells = true;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _maxCells;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _GoldPerTIck;
    
    public CityNodeViewModel CityNode {
        get {
            return ((CityNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(CityNodeViewModel);
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CityNodeController>());
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void maxCellsChanged(Int32 value) {
    }
    
    public override void Bind() {
        base.Bind();
        if (this._BindmaxCells) {
            this.BindProperty(CityNode._maxCellsProperty, this.maxCellsChanged);
        }
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        CityNodeViewModel cityNode = ((CityNodeViewModel)(viewModel));
        cityNode.maxCells = this._maxCells;
        cityNode.GoldPerTIck = this._GoldPerTIck;
    }
    
    public virtual void ExecuteaddUnit(UnitViewModel unit) {
        this.ExecuteCommand(CityNode.addUnit, unit);
    }
}

public partial class CityNodeView : CityNodeViewViewBase {
}

public class SettingsViewViewBase : SettingsViewBase {
    
    [UFToggleGroup("speed")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("speedChanged")]
    public bool _Bindspeed = true;
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<SettingsController>());
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void speedChanged(Single value) {
    }
    
    public override void Bind() {
        base.Bind();
        if (this._Bindspeed) {
            this.BindProperty(Settings._speedProperty, this.speedChanged);
        }
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

public class UnitViewViewBase : EntityView {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _owner;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public UnitState _state;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _currentMapNode;
    
    public UnitViewModel Unit {
        get {
            return ((UnitViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(UnitViewModel);
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<UnitController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        UnitViewModel unit = ((UnitViewModel)(viewModel));
        unit.owner = this._owner == null ? null : this._owner.ViewModelObject as OwnerViewModel;
        unit.state = this._state;
        unit.currentMapNode = this._currentMapNode == null ? null : this._currentMapNode.ViewModelObject as MapNodeViewModel;
    }
    
    public virtual void ExecuteGoTo(MapNodeViewModel mapNode) {
        this.ExecuteCommand(Unit.GoTo, mapNode);
    }
}

public partial class UnitView : UnitViewViewBase {
}

public class MapNodeViewViewBase : EntityView {
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public ViewBase _owner;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Boolean _isVisible;
    
    public MapNodeViewModel MapNode {
        get {
            return ((MapNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(MapNodeViewModel);
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<MapNodeController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        MapNodeViewModel mapNode = ((MapNodeViewModel)(viewModel));
        mapNode.owner = this._owner == null ? null : this._owner.ViewModelObject as OwnerViewModel;
        mapNode.isVisible = this._isVisible;
    }
}

public partial class MapNodeView : MapNodeViewViewBase {
}

public class CaveNodeViewViewBase : MapNodeView {
    
    [UFToggleGroup("goldLevel")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("goldLevelChanged")]
    public bool _BindgoldLevel = true;
    
    [UFToggleGroup("attackLevel")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("attackLevelChanged")]
    public bool _BindattackLevel = true;
    
    [UFToggleGroup("defenseLevel")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("defenseLevelChanged")]
    public bool _BinddefenseLevel = true;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _goldLevel;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _attackLevel;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public Int32 _defenseLevel;
    
    public CaveNodeViewModel CaveNode {
        get {
            return ((CaveNodeViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override System.Type ViewModelType {
        get {
            return typeof(CaveNodeViewModel);
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CaveNodeController>());
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void goldLevelChanged(Int32 value) {
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void attackLevelChanged(Int32 value) {
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void defenseLevelChanged(Int32 value) {
    }
    
    public override void Bind() {
        base.Bind();
        if (this._BindgoldLevel) {
            this.BindProperty(CaveNode._goldLevelProperty, this.goldLevelChanged);
        }
        if (this._BindattackLevel) {
            this.BindProperty(CaveNode._attackLevelProperty, this.attackLevelChanged);
        }
        if (this._BinddefenseLevel) {
            this.BindProperty(CaveNode._defenseLevelProperty, this.defenseLevelChanged);
        }
    }
    
    protected override void InitializeViewModel(ViewModel viewModel) {
        base.InitializeViewModel(viewModel);
        CaveNodeViewModel caveNode = ((CaveNodeViewModel)(viewModel));
        caveNode.goldLevel = this._goldLevel;
        caveNode.attackLevel = this._attackLevel;
        caveNode.defenseLevel = this._defenseLevel;
    }
}

public partial class CaveNodeView : CaveNodeViewViewBase {
}

public class EntityViewViewBase : EntityViewBase {
    
    [UFToggleGroup("defence")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("defenceChanged")]
    public bool _Binddefence = true;
    
    [UFToggleGroup("attack")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("attackChanged")]
    public bool _Bindattack = true;
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<EntityController>());
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void defenceChanged(Int32 value) {
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void attackChanged(Int32 value) {
    }
    
    public override void Bind() {
        base.Bind();
        if (this._Binddefence) {
            this.BindProperty(Entity._defenceProperty, this.defenceChanged);
        }
        if (this._Bindattack) {
            this.BindProperty(Entity._attackProperty, this.attackChanged);
        }
    }
}

public partial class EntityView : EntityViewViewBase {
}

public class OwnerViewViewBase : OwnerViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<OwnerController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class OwnerView : OwnerViewViewBase {
}

public class TopPanelViewViewBase : OwnerViewBase {
    
    [UFToggleGroup("money")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("moneyChanged")]
    public bool _Bindmoney = true;
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<OwnerController>());
    }
    
    /// Subscribes to the property and is notified anytime the value changes.
    public virtual void moneyChanged(Int32 value) {
    }
    
    public override void Bind() {
        base.Bind();
        if (this._Bindmoney) {
            this.BindProperty(Owner._moneyProperty, this.moneyChanged);
        }
    }
}

public partial class TopPanelView : TopPanelViewViewBase {
}

public class CityCellViewViewBase : CityCellViewBase {
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<CityCellController>());
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class CityCellView : CityCellViewViewBase {
}
