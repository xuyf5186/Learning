var canvas=document.getElementById('canvas')
ctx=canvas.getContext('2d')
const N=200//粒子总数
var max=5000,mmax=100//最大距离(px^2)
var rgb='#000000'
var dots=[];
resize()
window.onresize=resize;
function resize() {//画布自适应窗口
	canvas.width=window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth
	canvas.height=window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight

}
var RAF=(function(){
	 return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame || function(callback) {
          window.setTimeout(callback, 1000 / 60);
      };
})();
//初始化粒子位置与速度
for (var i = 0; i < N; i++) {
	var x=Math.random()*canvas.width;
	var y=Math.random()*canvas.height;
	var xa=Math.random()*2-1;
	var ya=Math.random()*2-1;
	dots.push({
      x: x,
      y: y,
      xa: xa,
      ya: ya,
    })
}
var warea={x:null,y:null}
window.onmousemove=function(e) {//获取鼠标位置
	e=e || window.event
	warea.x=e.clientX
	warea.y=e.clientY
}
window.onmouseout=function(e) {
	warea.x=null
	warea.y=null
}
window.onmousedown=function(e) {
	warea.x=null
	warea.y=null

}
var dis,radio,i,j
ctx.fillStyle="#000000"

function DotsMove() {
	ctx.clearRect(0,0,canvas.width,canvas.height)//清空画布
	dots.forEach(function(dot) {//画点
	//粒子位移
	dot.x+=dot.xa;
	dot.y+=dot.ya;
	//遇到边界反向
	dot.xa*=(dot.x>canvas.width||dot.x<0)?-1:1
	dot.ya*=(dot.y>canvas.height||dot.y<0)?-1:1
	ctx.beginPath()
	ctx.arc(dot.x,dot.y,1,0,2*Math.PI)
	ctx.closePath()
	ctx.fill()
	})
	for (i = 0; i < dots.length-1; i++) {
		for (j = i+1; j < dots.length; j++) {
				dis=(dots[i].x-dots[j].x)*(dots[i].x-dots[j].x)+(dots[i].y-dots[j].y)*(dots[i].y-dots[j].y)
				if(dis<max)//距离小于max
				{

					radio=(max-dis)/max
					ctx.beginPath()
					ctx.lineWidth=radio/2
					ctx.moveTo(dots[i].x,dots[i].y)
					ctx.lineTo(dots[j].x,dots[j].y)
					ctx.stroke()
				}
		}
	}
	if(warea.x!=null && warea.y!=null)
	{
		for (i = 0; i < dots.length; i++) {
			dis=Math.sqrt((dots[i].x-warea.x)*(dots[i].x-warea.x)+(dots[i].y-warea.y)*(dots[i].y-warea.y))
			if(dis<mmax)//距离小于max
			{
				if(dis>mmax/2)
				{
					dots[i].x-=(dots[i].x-warea.x)*0.03
					dots[i].y-=(dots[i].y-warea.y)*0.03
				}
				
				radio=(mmax-dis)/mmax
				ctx.beginPath()
				ctx.lineWidth=radio/2
				ctx.moveTo(dots[i].x,dots[i].y)
				ctx.lineTo(warea.x,warea.y)
				ctx.stroke()
			}
		}
	}
	RAF(DotsMove,20);
}
DotsMove()
// setInterval(DotsMove,20);

