<!-- default file list -->
*Files to look at*:

* [DrillDownControl.cs](./CS/Q212065/DrillDownControl.cs) (VB: [DrillDownControl.vb](./VB/Q212065/DrillDownControl.vb))
* [Form1.cs](./CS/Q212065/Form1.cs) (VB: [Form1.vb](./VB/Q212065/Form1.vb))
<!-- default file list end -->
# How to display a Drill Down data source within the PopupContainerEdit


<p>To accomplish this task, assign the RepositoryItemPopupContainerEdit control to any data field. Then, place the GridControl on the PopupContainerControl, assigned to the RepositoryItemPopupContainerEdit.PopupControl property. Within the RepositoryItemPopupContainerEdit event handler, create a PivotDrillDownDataSource via the PivotGridControl.Cells.FocusedCellInfo.CreateDrillDownDataSource method and bind it to the GridView.</p>

<br/>


