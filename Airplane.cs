public class Airplane {
	public bool active;
	public int x, y;
	public int cargo, cargoCapacity;
	private int xMoveDirection;
	private int yMoveDirection;
	
	public void SetMoveDirection(int xMoveDir, int yMoveDir){
		xMoveDirection = xMoveDir;
		yMoveDirection = yMoveDir;
	}

	bool CheckBounds(){
		if (x == 0){
			if (xMoveDirection < 0) {
				return false;
			} else if (y==8 && yMoveDirection > 0) {
				return false;
			} else if (y==0 && yMoveDirection < 0) {
				return false;
			} else {
				return true;
			}
		} else if (x == 15){
			if (xMoveDirection > 0) {
				return false;
			} else if (y==8 && yMoveDirection > 0) {
				return false;
			} else if (y==0 && yMoveDirection < 0) {
				return false;
			} else {
				return true;
			}
		} else if (y == 0){
			if (yMoveDirection < 0) {
				return false;
			} else if (x==15 && xMoveDirection > 0) {
				return false;
			} else if (x==0 && xMoveDirection < 0) {
				return false;
			} else {
				return true;
			}
		} else if (y == 8) {
			if (yMoveDirection > 0) {
				return false;
			} else if (x==15 && xMoveDirection > 0) {
				return false;
			} else if (x==0 && xMoveDirection < 0) {
				return false;
			} else {
				return true;
			}
		} else {
			return true;
		}
	}

	public void MoveNow() { 
		if (CheckBounds()){
			x += xMoveDirection;
			y += yMoveDirection;
			xMoveDirection = 0;
			yMoveDirection = 0;
		}
		//redraw board then draw plane in new position
	}
}
