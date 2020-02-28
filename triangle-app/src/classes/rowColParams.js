class RowColParams {
    constructor(row, col) {
        this._row = row;
        this._col = col;
    }
    get row() { return this._row; }
    get col() { return this._col; }
}


export default RowColParams;