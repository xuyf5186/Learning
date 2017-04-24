var chess = document.getElementById('chess');
var context = chess.getContext('2d');
var player = 1; //1黑棋，0白棋
var wins = []; //赢法数组
var myWin = [];
var computeWin = [];
var a = []; //棋盘落子数组
var count = 0;
var over = false;
var InitArray = function() {
	var i, j, k;
	for (i = 0; i < 15; i++) {
		wins[i] = [];
		for (j = 0; j < 15; j++)
			wins[i][j] = [];
	}
	for (i = 0; i < 15; i++) {
		for (j = 0; j < 11; j++) {
			for (k = 0; k < 5; k++)
				wins[i][j + k][count] = true;
			count++;
		}
	}
	for (i = 0; i < 15; i++) {
		for (j = 0; j < 11; j++) {
			for (k = 0; k < 5; k++)	
				wins[j + k][i][count] = true;
			count++;
		}
	}
	for (i = 0; i < 11; i++) {
		for (j = 0; j < 11; j++) {
			for (k = 0; k < 5; k++)
				wins[i + k][j + k][count] = true;
			count++;
		}
	}
	for (i = 0; i < 11; i++) {
		for (j = 14; j > 3; j--) {
			for (k = 0; k < 5; k++)
				wins[i + k][j - k][count] = true;
			count++;
		}
	}
	//console.log(count);
	for (i = 0; i < count; i++) {
		myWin[i] = 0;
		computeWin[i] = 0;
	}
	for (i = 0; i < 15; i++) {
		a[i] = [];
		for (j = 0; j < 15; j++) {
			a[i][j] = 0;
		}
	}
}
InitArray()
context.strokeStyle = "#BFBFBF"; //描边的背景

var image = new Image();
image.src = 'images/logo1.png'
image.onload = function() { //图片加载好后再绘制
	context.drawImage(image, 0, 0, 450, 450);
	drawChessBoard();
}
var drawChessBoard = function() {
	for (var i = 0; i < 15; i++) {
		context.moveTo(15 + 30 * i, 15)
		context.lineTo(15 + 30 * i, 435);
		context.stroke(); //描边
		context.moveTo(15, 15 + 30 * i)
		context.lineTo(435, 15 + 30 * i);
		context.stroke();

	}
}
var onStep = function(i, j, me) {
	context.beginPath();
	context.arc(15 + 30 * i, 15 + 30 * j, 13, 0, 2 * Math.PI); //(x,y,角度1，角度2)
	context.closePath(); //                  圆心坐标1，半径1
	var gradient = context.createRadialGradient(15 + 30 * i + 2, 15 + 30 * j - 2, 13, 15 + 30 * i + 2, 15 + 30 * j - 2, 0)
	if (me) //黑棋
	{
		gradient.addColorStop(0, "#0a0a0a");
		gradient.addColorStop(1, "#636766");
	} else //白棋
	{
		gradient.addColorStop(0, "#d1d1d1");
		gradient.addColorStop(1, "#f9f9f9");

	}
	context.fillStyle = gradient; //填充背景
	context.fill(); //填充
}

chess.onclick = function(e) {
	if (over) return;
	if (!player) return;
	var x = Math.floor(e.offsetX / 30); //j
	var y = Math.floor(e.offsetY / 30); //i
	if (a[y][x] == 0) {
		onStep(x, y, player);
		a[y][x] = 1;
		for (var i = 0; i < count; i++) {
			if (wins[y][x][i]) {
				myWin[i]++;
				computeWin[i] = 6;
				if (myWin[i] == 5) {
					window.alert("你赢了")
					over = true;
				}
			}
		}
		if (!over) {
			player = !player;
			computerAI();
		}
	}
}

var computerAI = function() {
	var i, j, k;
	var myScore = [];
	var computeScore = [];
	var max=0,maxi=0,maxj=0;
	for (i = 0; i < 15; i++) {
		myScore[i] = [];
		computeScore[i] = [];
		for (j = 0; j < 15; j++) {
			myScore[i][j] = 0;
			computeScore[i][j] = 0;
		}
	}
	for (i = 0; i < 15; i++) {
		for (j = 0; j < 15; j++) {
			if (a[i][j] == 0) {
				for (k = 0; k < count; k++) {
					if (wins[i][j][k]) {
						if(myWin[k]==1)
							myScore[i][j] += 200;
						if(myWin[k]==2)
							myScore[i][j] += 400;
						if(myWin[k]==3)
							myScore[i][j] += 2000;
						if(myWin[k]==4)
							myScore[i][j] += 10000;
						if (computeWin[k]==1)
							computeScore[i][j] += 400;
						if (computeWin[k]==2)
							computeScore[i][j] += 800;
						if (computeWin[k]==3)
							computeScore[i][j] += 2200;
						if (computeWin[k]==4)
							computeScore[i][j] += 20000;
					}
				}
				if(myScore[i][j]>max)
				{
					max=myScore[i][j];
					maxi=i;
					maxj=j;
				}
				else if(myScore[i][j]==max)
				{
					if(computeScore[i][j]>computeScore[maxi][maxj])
					{
						//max=myScore[i][j];
						maxi=i;
						maxj=j;
					}
				}
				if(computeScore[i][j]>max)
				{
					max=computeScore[i][j];
					maxi=i;
					maxj=j;
				}
				else if(computeScore[i][j]==max)
				{
					if(myScore[i][j]>myScore[maxi][maxj])
					{
						//max=computeScore[i][j];
						maxi=i;
						maxj=j;
					}
				}
			}
		}
	}
	onStep(maxj,maxi,0)
	a[maxi][maxj] = 2;
		for (var i = 0; i < count; i++) {
			if (wins[maxi][maxj][i]) {
				myWin[i]==6;
				computeWin[i]++;
				if (computeWin[i] == 5) {
					window.alert("你输了")
					over = true;
				}
			}
		}
	player=!player
}