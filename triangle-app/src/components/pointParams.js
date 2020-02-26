class PointParams {
    constructor(top1, left1, top2, left2, top3, left3) {
        this._left1 = left1;
        this._top1 = top1;
        this._left2 = left2;
        this._top2 = top2;
        this._left3 = left3;
        this._top3 = top3;
    }

    get top1() {return this._top1; }
    get left1() {return this._left1;}
    get top2() {return this._top2; }
    get left2() {return this._left2;}
    get top3() {return this._top3; }
    get left3() {return this._left3;}
}
export default PointParams;