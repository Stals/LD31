using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[DiagramInfoAttribute("Game")]
public class OwnerViewModelBase : ViewModel {
    
    public P<Vector3> _colorProperty;
    
    public P<Int32> _moneyProperty;
    
    public OwnerViewModelBase(OwnerControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public OwnerViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _colorProperty = new P<Vector3>(this, "color");
        _moneyProperty = new P<Int32>(this, "money");
    }
}

public partial class OwnerViewModel : OwnerViewModelBase {
    
    private MapNodeViewModel _ParentMapNode;
    
    private UnitViewModel _ParentUnit;
    
    public OwnerViewModel(OwnerControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public OwnerViewModel() : 
            base() {
    }
    
    public virtual P<Vector3> colorProperty {
        get {
            return this._colorProperty;
        }
    }
    
    public virtual Vector3 color {
        get {
            return _colorProperty.Value;
        }
        set {
            _colorProperty.Value = value;
        }
    }
    
    public virtual P<Int32> moneyProperty {
        get {
            return this._moneyProperty;
        }
    }
    
    public virtual Int32 money {
        get {
            return _moneyProperty.Value;
        }
        set {
            _moneyProperty.Value = value;
        }
    }
    
    public virtual MapNodeViewModel ParentMapNode {
        get {
            return this._ParentMapNode;
        }
        set {
            _ParentMapNode = value;
        }
    }
    
    public virtual UnitViewModel ParentUnit {
        get {
            return this._ParentUnit;
        }
        set {
            _ParentUnit = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeVector3("color", this.color);
        stream.SerializeInt("money", this.money);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.color = stream.DeserializeVector3("color");;
        		this.money = stream.DeserializeInt("money");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_colorProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_moneyProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
    }
}

[DiagramInfoAttribute("Game")]
public class MapNodeViewModelBase : EntityViewModel {
    
    public P<OwnerViewModel> _ownerProperty;
    
    public P<Boolean> _isVisibleProperty;
    
    public ModelCollection<LinkViewModel> _connectionsProperty;
    
    protected CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel> _Interact;
    
    protected CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel> _Uninteract;
    
    public MapNodeViewModelBase(MapNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MapNodeViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _ownerProperty = new P<OwnerViewModel>(this, "owner");
        _isVisibleProperty = new P<Boolean>(this, "isVisible");
        _connectionsProperty = new ModelCollection<LinkViewModel>(this, "connections");
        _connectionsProperty.CollectionChanged += connectionsCollectionChanged;
    }
    
    protected virtual void connectionsCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
    }
}

public partial class MapNodeViewModel : MapNodeViewModelBase {
    
    private UnitViewModel _ParentUnit;
    
    private MapViewModel _ParentMap;
    
    private LinkViewModel _ParentLink;
    
    public MapNodeViewModel(MapNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MapNodeViewModel() : 
            base() {
    }
    
    public virtual P<OwnerViewModel> ownerProperty {
        get {
            return this._ownerProperty;
        }
    }
    
    public virtual OwnerViewModel owner {
        get {
            return _ownerProperty.Value;
        }
        set {
            _ownerProperty.Value = value;
            if (value != null) value.ParentMapNode = this;
        }
    }
    
    public virtual P<Boolean> isVisibleProperty {
        get {
            return this._isVisibleProperty;
        }
    }
    
    public virtual Boolean isVisible {
        get {
            return _isVisibleProperty.Value;
        }
        set {
            _isVisibleProperty.Value = value;
        }
    }
    
    public virtual ModelCollection<LinkViewModel> connections {
        get {
            return this._connectionsProperty;
        }
    }
    
    public virtual CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel> Interact {
        get {
            return _Interact;
        }
        set {
            _Interact = value;
        }
    }
    
    public virtual CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel> Uninteract {
        get {
            return _Uninteract;
        }
        set {
            _Uninteract = value;
        }
    }
    
    public virtual UnitViewModel ParentUnit {
        get {
            return this._ParentUnit;
        }
        set {
            _ParentUnit = value;
        }
    }
    
    public virtual MapViewModel ParentMap {
        get {
            return this._ParentMap;
        }
        set {
            _ParentMap = value;
        }
    }
    
    public virtual LinkViewModel ParentLink {
        get {
            return this._ParentLink;
        }
        set {
            _ParentLink = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        base.WireCommands(controller);
        var mapNode = controller as MapNodeControllerBase;
        this.Interact = new CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel>(this, mapNode.Interact);
        this.Uninteract = new CommandWithSenderAndArgument<MapNodeViewModel, UnitViewModel>(this, mapNode.Uninteract);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		if (stream.DeepSerialize) stream.SerializeObject("owner", this.owner);
        stream.SerializeBool("isVisible", this.isVisible);
        if (stream.DeepSerialize) stream.SerializeArray("connections", this.connections);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		if (stream.DeepSerialize) this.owner = stream.DeserializeObject<OwnerViewModel>("owner");
        		this.isVisible = stream.DeserializeBool("isVisible");;
if (stream.DeepSerialize) {
        this.connections.Clear();
        this.connections.AddRange(stream.DeserializeObjectArray<LinkViewModel>("connections"));
}
    }
    
    public override void Unbind() {
        base.Unbind();
        _connectionsProperty.CollectionChanged -= connectionsCollectionChanged;
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_ownerProperty, true, false, false));
        list.Add(new ViewModelPropertyInfo(_isVisibleProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_connectionsProperty, true, true, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("Interact", Interact) { ParameterType = typeof(UnitViewModel) });
        list.Add(new ViewModelCommandInfo("Uninteract", Uninteract) { ParameterType = typeof(UnitViewModel) });
    }
    
    protected override void connectionsCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
        foreach (var item in args.OldItems.OfType<LinkViewModel>()) item.ParentMapNode = null;;
        foreach (var item in args.NewItems.OfType<LinkViewModel>()) item.ParentMapNode = this;;
    }
}

[DiagramInfoAttribute("Game")]
public class CityNodeViewModelBase : MapNodeViewModel {
    
    private IDisposable _HasEmptyCellsDisposable;
    
    public P<Int32> _maxCellsProperty;
    
    public P<Int32> _GoldPerTIckProperty;
    
    public P<Boolean> _HasEmptyCellsProperty;
    
    public ModelCollection<CityCellViewModel> _cellsProperty;
    
    protected CommandWithSenderAndArgument<CityNodeViewModel, UnitViewModel> _addUnit;
    
    public CityNodeViewModelBase(CityNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CityNodeViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _maxCellsProperty = new P<Int32>(this, "maxCells");
        _GoldPerTIckProperty = new P<Int32>(this, "GoldPerTIck");
        _HasEmptyCellsProperty = new P<Boolean>(this, "HasEmptyCells");
        _cellsProperty = new ModelCollection<CityCellViewModel>(this, "cells");
        _cellsProperty.CollectionChanged += cellsCollectionChanged;
        this.ResetHasEmptyCells();
    }
    
    public virtual void ResetHasEmptyCells() {
        if (_HasEmptyCellsDisposable != null) _HasEmptyCellsDisposable.Dispose();
        _HasEmptyCellsDisposable = _HasEmptyCellsProperty.ToComputed( ComputeHasEmptyCells, this.GetHasEmptyCellsDependents().ToArray() ).DisposeWith(this);
    }
    
    protected virtual void cellsCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
    }
    
    public virtual Boolean ComputeHasEmptyCells() {
        return default(Boolean);
    }
    
    public virtual IEnumerable<IObservableProperty> GetHasEmptyCellsDependents() {
        yield return _maxCellsProperty;
        yield break;
    }
}

public partial class CityNodeViewModel : CityNodeViewModelBase {
    
    public CityNodeViewModel(CityNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CityNodeViewModel() : 
            base() {
    }
    
    public virtual P<Int32> maxCellsProperty {
        get {
            return this._maxCellsProperty;
        }
    }
    
    public virtual Int32 maxCells {
        get {
            return _maxCellsProperty.Value;
        }
        set {
            _maxCellsProperty.Value = value;
        }
    }
    
    public virtual P<Int32> GoldPerTIckProperty {
        get {
            return this._GoldPerTIckProperty;
        }
    }
    
    public virtual Int32 GoldPerTIck {
        get {
            return _GoldPerTIckProperty.Value;
        }
        set {
            _GoldPerTIckProperty.Value = value;
        }
    }
    
    public virtual P<Boolean> HasEmptyCellsProperty {
        get {
            return this._HasEmptyCellsProperty;
        }
    }
    
    public virtual Boolean HasEmptyCells {
        get {
            return _HasEmptyCellsProperty.Value;
        }
        set {
            _HasEmptyCellsProperty.Value = value;
        }
    }
    
    public virtual ModelCollection<CityCellViewModel> cells {
        get {
            return this._cellsProperty;
        }
    }
    
    public virtual CommandWithSenderAndArgument<CityNodeViewModel, UnitViewModel> addUnit {
        get {
            return _addUnit;
        }
        set {
            _addUnit = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        base.WireCommands(controller);
        var cityNode = controller as CityNodeControllerBase;
        this.addUnit = new CommandWithSenderAndArgument<CityNodeViewModel, UnitViewModel>(this, cityNode.addUnit);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeInt("maxCells", this.maxCells);
        stream.SerializeInt("GoldPerTIck", this.GoldPerTIck);
        if (stream.DeepSerialize) stream.SerializeArray("cells", this.cells);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.maxCells = stream.DeserializeInt("maxCells");;
        		this.GoldPerTIck = stream.DeserializeInt("GoldPerTIck");;
if (stream.DeepSerialize) {
        this.cells.Clear();
        this.cells.AddRange(stream.DeserializeObjectArray<CityCellViewModel>("cells"));
}
    }
    
    public override void Unbind() {
        base.Unbind();
        _cellsProperty.CollectionChanged -= cellsCollectionChanged;
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_maxCellsProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_GoldPerTIckProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_HasEmptyCellsProperty, false, false, false, true));
        list.Add(new ViewModelPropertyInfo(_cellsProperty, true, true, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("addUnit", addUnit) { ParameterType = typeof(UnitViewModel) });
    }
    
    protected override void cellsCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
        foreach (var item in args.OldItems.OfType<CityCellViewModel>()) item.ParentCityNode = null;;
        foreach (var item in args.NewItems.OfType<CityCellViewModel>()) item.ParentCityNode = this;;
    }
}

[DiagramInfoAttribute("Game")]
public class CaveNodeViewModelBase : MapNodeViewModel {
    
    public P<Int32> _goldLevelProperty;
    
    public P<Int32> _attackLevelProperty;
    
    public P<Int32> _defenseLevelProperty;
    
    public P<Int32> _goldProperty;
    
    public CaveNodeViewModelBase(CaveNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CaveNodeViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _goldLevelProperty = new P<Int32>(this, "goldLevel");
        _attackLevelProperty = new P<Int32>(this, "attackLevel");
        _defenseLevelProperty = new P<Int32>(this, "defenseLevel");
        _goldProperty = new P<Int32>(this, "gold");
    }
}

public partial class CaveNodeViewModel : CaveNodeViewModelBase {
    
    public CaveNodeViewModel(CaveNodeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CaveNodeViewModel() : 
            base() {
    }
    
    public virtual P<Int32> goldLevelProperty {
        get {
            return this._goldLevelProperty;
        }
    }
    
    public virtual Int32 goldLevel {
        get {
            return _goldLevelProperty.Value;
        }
        set {
            _goldLevelProperty.Value = value;
        }
    }
    
    public virtual P<Int32> attackLevelProperty {
        get {
            return this._attackLevelProperty;
        }
    }
    
    public virtual Int32 attackLevel {
        get {
            return _attackLevelProperty.Value;
        }
        set {
            _attackLevelProperty.Value = value;
        }
    }
    
    public virtual P<Int32> defenseLevelProperty {
        get {
            return this._defenseLevelProperty;
        }
    }
    
    public virtual Int32 defenseLevel {
        get {
            return _defenseLevelProperty.Value;
        }
        set {
            _defenseLevelProperty.Value = value;
        }
    }
    
    public virtual P<Int32> goldProperty {
        get {
            return this._goldProperty;
        }
    }
    
    public virtual Int32 gold {
        get {
            return _goldProperty.Value;
        }
        set {
            _goldProperty.Value = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        base.WireCommands(controller);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeInt("goldLevel", this.goldLevel);
        stream.SerializeInt("attackLevel", this.attackLevel);
        stream.SerializeInt("defenseLevel", this.defenseLevel);
        stream.SerializeInt("gold", this.gold);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.goldLevel = stream.DeserializeInt("goldLevel");;
        		this.attackLevel = stream.DeserializeInt("attackLevel");;
        		this.defenseLevel = stream.DeserializeInt("defenseLevel");;
        		this.gold = stream.DeserializeInt("gold");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_goldLevelProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_attackLevelProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_defenseLevelProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_goldProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
    }
}

[DiagramInfoAttribute("Game")]
public class UnitViewModelBase : EntityViewModel {
    
    public P<OwnerViewModel> _ownerProperty;
    
    public P<UnitState> _stateProperty;
    
    public P<MapNodeViewModel> _currentMapNodeProperty;
    
    protected CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel> _GoTo;
    
    protected CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel> _InitUnit;
    
    protected CommandWithSender<UnitViewModel> _UpdateMe;
    
    public UnitViewModelBase(UnitControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public UnitViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _ownerProperty = new P<OwnerViewModel>(this, "owner");
        _stateProperty = new P<UnitState>(this, "state");
        _currentMapNodeProperty = new P<MapNodeViewModel>(this, "currentMapNode");
    }
}

public partial class UnitViewModel : UnitViewModelBase {
    
    private MapNodeViewModel _ParentMapNode;
    
    private CityNodeViewModel _ParentCityNode;
    
    private CityCellViewModel _ParentCityCell;
    
    public UnitViewModel(UnitControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public UnitViewModel() : 
            base() {
    }
    
    public virtual P<OwnerViewModel> ownerProperty {
        get {
            return this._ownerProperty;
        }
    }
    
    public virtual OwnerViewModel owner {
        get {
            return _ownerProperty.Value;
        }
        set {
            _ownerProperty.Value = value;
            if (value != null) value.ParentUnit = this;
        }
    }
    
    public virtual P<UnitState> stateProperty {
        get {
            return this._stateProperty;
        }
    }
    
    public virtual UnitState state {
        get {
            return _stateProperty.Value;
        }
        set {
            _stateProperty.Value = value;
        }
    }
    
    public virtual P<MapNodeViewModel> currentMapNodeProperty {
        get {
            return this._currentMapNodeProperty;
        }
    }
    
    public virtual MapNodeViewModel currentMapNode {
        get {
            return _currentMapNodeProperty.Value;
        }
        set {
            _currentMapNodeProperty.Value = value;
            if (value != null) value.ParentUnit = this;
        }
    }
    
    public virtual CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel> GoTo {
        get {
            return _GoTo;
        }
        set {
            _GoTo = value;
        }
    }
    
    public virtual CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel> InitUnit {
        get {
            return _InitUnit;
        }
        set {
            _InitUnit = value;
        }
    }
    
    public virtual CommandWithSender<UnitViewModel> UpdateMe {
        get {
            return _UpdateMe;
        }
        set {
            _UpdateMe = value;
        }
    }
    
    public virtual MapNodeViewModel ParentMapNode {
        get {
            return this._ParentMapNode;
        }
        set {
            _ParentMapNode = value;
        }
    }
    
    public virtual CityNodeViewModel ParentCityNode {
        get {
            return this._ParentCityNode;
        }
        set {
            _ParentCityNode = value;
        }
    }
    
    public virtual CityCellViewModel ParentCityCell {
        get {
            return this._ParentCityCell;
        }
        set {
            _ParentCityCell = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        base.WireCommands(controller);
        var unit = controller as UnitControllerBase;
        this.GoTo = new CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel>(this, unit.GoTo);
        this.InitUnit = new CommandWithSenderAndArgument<UnitViewModel, MapNodeViewModel>(this, unit.InitUnit);
        this.UpdateMe = new CommandWithSender<UnitViewModel>(this, unit.UpdateMe);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		if (stream.DeepSerialize) stream.SerializeObject("owner", this.owner);
		stream.SerializeInt("state", (int)this.state);
		if (stream.DeepSerialize) stream.SerializeObject("currentMapNode", this.currentMapNode);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		if (stream.DeepSerialize) this.owner = stream.DeserializeObject<OwnerViewModel>("owner");
		this.state = (UnitState)stream.DeserializeInt("state");
		if (stream.DeepSerialize) this.currentMapNode = stream.DeserializeObject<MapNodeViewModel>("currentMapNode");
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_ownerProperty, true, false, false));
        list.Add(new ViewModelPropertyInfo(_stateProperty, false, false, true));
        list.Add(new ViewModelPropertyInfo(_currentMapNodeProperty, true, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("GoTo", GoTo) { ParameterType = typeof(MapNodeViewModel) });
        list.Add(new ViewModelCommandInfo("InitUnit", InitUnit) { ParameterType = typeof(MapNodeViewModel) });
        list.Add(new ViewModelCommandInfo("UpdateMe", UpdateMe) { ParameterType = typeof(void) });
    }
}

[DiagramInfoAttribute("Game")]
public class CityCellViewModelBase : ViewModel {
    
    private IDisposable _isEmptyDisposable;
    
    public P<UnitViewModel> _unitProperty;
    
    public P<Boolean> _isEmptyProperty;
    
    public CityCellViewModelBase(CityCellControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CityCellViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _unitProperty = new P<UnitViewModel>(this, "unit");
        _isEmptyProperty = new P<Boolean>(this, "isEmpty");
        this.ResetisEmpty();
        this.BindProperty(_unitProperty, p=> ResetisEmpty());
    }
    
    public virtual void ResetisEmpty() {
        if (_isEmptyDisposable != null) _isEmptyDisposable.Dispose();
        _isEmptyDisposable = _isEmptyProperty.ToComputed( ComputeisEmpty, this.GetisEmptyDependents().ToArray() ).DisposeWith(this);
    }
    
    public virtual Boolean ComputeisEmpty() {
        return default(Boolean);
    }
    
    public virtual IEnumerable<IObservableProperty> GetisEmptyDependents() {
        if (_unitProperty.Value != null) {
        }
        yield break;
    }
}

public partial class CityCellViewModel : CityCellViewModelBase {
    
    private CityNodeViewModel _ParentCityNode;
    
    public CityCellViewModel(CityCellControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public CityCellViewModel() : 
            base() {
    }
    
    public virtual P<UnitViewModel> unitProperty {
        get {
            return this._unitProperty;
        }
    }
    
    public virtual UnitViewModel unit {
        get {
            return _unitProperty.Value;
        }
        set {
            _unitProperty.Value = value;
            if (value != null) value.ParentCityCell = this;
        }
    }
    
    public virtual P<Boolean> isEmptyProperty {
        get {
            return this._isEmptyProperty;
        }
    }
    
    public virtual Boolean isEmpty {
        get {
            return _isEmptyProperty.Value;
        }
        set {
            _isEmptyProperty.Value = value;
        }
    }
    
    public virtual CityNodeViewModel ParentCityNode {
        get {
            return this._ParentCityNode;
        }
        set {
            _ParentCityNode = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var cityCell = controller as CityCellControllerBase;
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		if (stream.DeepSerialize) stream.SerializeObject("unit", this.unit);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		if (stream.DeepSerialize) this.unit = stream.DeserializeObject<UnitViewModel>("unit");
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_unitProperty, true, false, false));
        list.Add(new ViewModelPropertyInfo(_isEmptyProperty, false, false, false, true));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
    }
}

[DiagramInfoAttribute("Game")]
public class EntityViewModelBase : ViewModel {
    
    public P<Int32> _attackProperty;
    
    public P<Int32> _defenceProperty;
    
    public P<ActionViewModel> _attackDelayProperty;
    
    protected CommandWithSenderAndArgument<EntityViewModel, Int32> _TakeDamage;
    
    public EntityViewModelBase(EntityControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public EntityViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _attackProperty = new P<Int32>(this, "attack");
        _defenceProperty = new P<Int32>(this, "defence");
        _attackDelayProperty = new P<ActionViewModel>(this, "attackDelay");
    }
}

public partial class EntityViewModel : EntityViewModelBase {
    
    public EntityViewModel(EntityControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public EntityViewModel() : 
            base() {
    }
    
    public virtual P<Int32> attackProperty {
        get {
            return this._attackProperty;
        }
    }
    
    public virtual Int32 attack {
        get {
            return _attackProperty.Value;
        }
        set {
            _attackProperty.Value = value;
        }
    }
    
    public virtual P<Int32> defenceProperty {
        get {
            return this._defenceProperty;
        }
    }
    
    public virtual Int32 defence {
        get {
            return _defenceProperty.Value;
        }
        set {
            _defenceProperty.Value = value;
        }
    }
    
    public virtual P<ActionViewModel> attackDelayProperty {
        get {
            return this._attackDelayProperty;
        }
    }
    
    public virtual ActionViewModel attackDelay {
        get {
            return _attackDelayProperty.Value;
        }
        set {
            _attackDelayProperty.Value = value;
            if (value != null) value.ParentEntity = this;
        }
    }
    
    public virtual CommandWithSenderAndArgument<EntityViewModel, Int32> TakeDamage {
        get {
            return _TakeDamage;
        }
        set {
            _TakeDamage = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var entity = controller as EntityControllerBase;
        this.TakeDamage = new CommandWithSenderAndArgument<EntityViewModel, Int32>(this, entity.TakeDamage);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeInt("attack", this.attack);
        stream.SerializeInt("defence", this.defence);
		if (stream.DeepSerialize) stream.SerializeObject("attackDelay", this.attackDelay);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.attack = stream.DeserializeInt("attack");;
        		this.defence = stream.DeserializeInt("defence");;
		if (stream.DeepSerialize) this.attackDelay = stream.DeserializeObject<ActionViewModel>("attackDelay");
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_attackProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_defenceProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_attackDelayProperty, true, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("TakeDamage", TakeDamage) { ParameterType = typeof(Int32) });
    }
}

[DiagramInfoAttribute("Game")]
public class MapViewModelBase : ViewModel {
    
    public ModelCollection<MapNodeViewModel> _nodesProperty;
    
    protected CommandWithSender<MapViewModel> _TestCommand;
    
    public MapViewModelBase(MapControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MapViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _nodesProperty = new ModelCollection<MapNodeViewModel>(this, "nodes");
        _nodesProperty.CollectionChanged += nodesCollectionChanged;
    }
    
    protected virtual void nodesCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
    }
}

public partial class MapViewModel : MapViewModelBase {
    
    public MapViewModel(MapControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MapViewModel() : 
            base() {
    }
    
    public virtual ModelCollection<MapNodeViewModel> nodes {
        get {
            return this._nodesProperty;
        }
    }
    
    public virtual CommandWithSender<MapViewModel> TestCommand {
        get {
            return _TestCommand;
        }
        set {
            _TestCommand = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var map = controller as MapControllerBase;
        this.TestCommand = new CommandWithSender<MapViewModel>(this, map.TestCommand);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        if (stream.DeepSerialize) stream.SerializeArray("nodes", this.nodes);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
if (stream.DeepSerialize) {
        this.nodes.Clear();
        this.nodes.AddRange(stream.DeserializeObjectArray<MapNodeViewModel>("nodes"));
}
    }
    
    public override void Unbind() {
        base.Unbind();
        _nodesProperty.CollectionChanged -= nodesCollectionChanged;
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_nodesProperty, true, true, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("TestCommand", TestCommand) { ParameterType = typeof(void) });
    }
    
    protected override void nodesCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
        foreach (var item in args.OldItems.OfType<MapNodeViewModel>()) item.ParentMap = null;;
        foreach (var item in args.NewItems.OfType<MapNodeViewModel>()) item.ParentMap = this;;
    }
}

[DiagramInfoAttribute("Game")]
public class ActionViewModelBase : ViewModel {
    
    public P<Single> _delayProperty;
    
    protected CommandWithSender<ActionViewModel> _Excecute;
    
    public ActionViewModelBase(ActionControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public ActionViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _delayProperty = new P<Single>(this, "delay");
    }
}

public partial class ActionViewModel : ActionViewModelBase {
    
    private EntityViewModel _ParentEntity;
    
    public ActionViewModel(ActionControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public ActionViewModel() : 
            base() {
    }
    
    public virtual P<Single> delayProperty {
        get {
            return this._delayProperty;
        }
    }
    
    public virtual Single delay {
        get {
            return _delayProperty.Value;
        }
        set {
            _delayProperty.Value = value;
        }
    }
    
    public virtual CommandWithSender<ActionViewModel> Excecute {
        get {
            return _Excecute;
        }
        set {
            _Excecute = value;
        }
    }
    
    public virtual EntityViewModel ParentEntity {
        get {
            return this._ParentEntity;
        }
        set {
            _ParentEntity = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var action = controller as ActionControllerBase;
        this.Excecute = new CommandWithSender<ActionViewModel>(this, action.Excecute);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeFloat("delay", this.delay);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.delay = stream.DeserializeFloat("delay");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_delayProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("Excecute", Excecute) { ParameterType = typeof(void) });
    }
}

[DiagramInfoAttribute("Game")]
public class LinkViewModelBase : ViewModel {
    
    public P<MapNodeViewModel> _node1Property;
    
    public P<MapNodeViewModel> _node2Property;
    
    public LinkViewModelBase(LinkControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public LinkViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _node1Property = new P<MapNodeViewModel>(this, "node1");
        _node2Property = new P<MapNodeViewModel>(this, "node2");
    }
}

public partial class LinkViewModel : LinkViewModelBase {
    
    private MapNodeViewModel _ParentMapNode;
    
    public LinkViewModel(LinkControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public LinkViewModel() : 
            base() {
    }
    
    public virtual P<MapNodeViewModel> node1Property {
        get {
            return this._node1Property;
        }
    }
    
    public virtual MapNodeViewModel node1 {
        get {
            return _node1Property.Value;
        }
        set {
            _node1Property.Value = value;
            if (value != null) value.ParentLink = this;
        }
    }
    
    public virtual P<MapNodeViewModel> node2Property {
        get {
            return this._node2Property;
        }
    }
    
    public virtual MapNodeViewModel node2 {
        get {
            return _node2Property.Value;
        }
        set {
            _node2Property.Value = value;
            if (value != null) value.ParentLink = this;
        }
    }
    
    public virtual MapNodeViewModel ParentMapNode {
        get {
            return this._ParentMapNode;
        }
        set {
            _ParentMapNode = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		if (stream.DeepSerialize) stream.SerializeObject("node1", this.node1);
		if (stream.DeepSerialize) stream.SerializeObject("node2", this.node2);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		if (stream.DeepSerialize) this.node1 = stream.DeserializeObject<MapNodeViewModel>("node1");
		if (stream.DeepSerialize) this.node2 = stream.DeserializeObject<MapNodeViewModel>("node2");
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_node1Property, true, false, false));
        list.Add(new ViewModelPropertyInfo(_node2Property, true, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
    }
}

[DiagramInfoAttribute("Game")]
public class SettingsViewModelBase : ViewModel {
    
    public P<Single> _speedProperty;
    
    public SettingsViewModelBase(SettingsControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public SettingsViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _speedProperty = new P<Single>(this, "speed");
    }
}

public partial class SettingsViewModel : SettingsViewModelBase {
    
    public SettingsViewModel(SettingsControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public SettingsViewModel() : 
            base() {
    }
    
    public virtual P<Single> speedProperty {
        get {
            return this._speedProperty;
        }
    }
    
    public virtual Single speed {
        get {
            return _speedProperty.Value;
        }
        set {
            _speedProperty.Value = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeFloat("speed", this.speed);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.speed = stream.DeserializeFloat("speed");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_speedProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
    }
}

public enum UnitState {
    
    InCity,
    
    Walking,
    
    Attacking,
    
    StandingOutside,
}
