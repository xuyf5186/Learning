var clock=document.getElementById('clock');
var context=clock.getContext('2d');
var width=context.canvas.width
var height=context.canvas.height
var cx=width/2;
var cy=height/2
var wr=cx,nr=cx-width/10;
var mDate;
function DrawBackground() {
	context.save()
	context.translate(cx,cx)//改变原点坐标
	context.beginPath();
	context.arc(0, 0, cx-width/40, 0, 2 * Math.PI); //外圆
	context.lineWidth=width/20;
	context.stroke()
	for (var i = 0; i <60; i++) {//时间刻度
		context.beginPath();
		if(i%5==0)
		{
			var j=i/5;
			context.arc(nr*Math.cos(Math.PI/6*j),nr*Math.sin(Math.PI/6*j),width/100,0,2*Math.PI)
			context.fill();
			context.font=width/20+"px Arial"
			context.textAlign="center"
			context.textBaseline="middle"
			var number=(2+j)%12+1;//3-12-3
			context.fillText(number,(nr-width/20)*Math.cos(Math.PI/6*j),(nr-width/20)*Math.sin(Math.PI/6*j))
		}
		else
		{
			context.arc(nr*Math.cos(Math.PI/30*i),nr*Math.sin(Math.PI/30*i),width/200,0,2*Math.PI)
			context.fill();
		}
	}
}
function DrawLine(rad,len,width) {
	context.restore()
	context.save()
	context.beginPath();
	context.lineWidth=width
	context.rotate(rad)
	context.lineCap="round"
	context.moveTo(0,this.width/20)
	context.lineTo(0,-len)
	context.stroke()
}
function DrawClock(hour,minute,second) {
	context.save()
	hour=hour%12;
	var rad;//角度
	var len;//长度
	rad=hour*Math.PI/6+minute*Math.PI/360
	len=wr/2
	DrawLine(rad,len,width*3/100)
	
	
	rad=minute*Math.PI/30
	len+=width/20
	DrawLine(rad,len,width*2/100)

	rad=second*Math.PI/30
	len+=width/20
	DrawLine(rad,len,width/100)
	context.restore()
}
function Draw() {
	context.clearRect(0,0,context.canvas.width,context.canvas.height)
	DrawBackground();
	mDate=new Date()
	DrawClock(mDate.getHours(),mDate.getMinutes(),mDate.getSeconds())
	context.restore()
}
Draw()
setInterval(Draw, 1000)