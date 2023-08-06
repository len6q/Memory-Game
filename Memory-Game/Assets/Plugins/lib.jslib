mergeInto(LibraryManager.library, {

ShowAdsInternalExtern: function (){
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onOpen: function() {
					console.log('opened!');
					gameInstance.SendMessage("PlayerOptions", "OpenAds");
				},
				onClose: function(wasShown) {
					console.log('closed!');
					gameInstance.SendMessage("PlayerOptions", "CloseAds");
				},
				onError: function(error) {
					console.log(error);					
				}
			}
		})
	},
	
ShowAdsRewardedExtern: function (){
	ysdk.adv.showRewardedVideo({
			callbacks: {
				onOpen: () => {
				  console.log('Video ad open.');
				  gameInstance.SendMessage("PlayerOptions", "OpenAds");
				},
				onRewarded: () => {
				  console.log('Rewarded!');
				},
				onClose: () => {
				  console.log('Video ad closed.');
				  gameInstance.SendMessage("PlayerOptions", "CloseAds");
				}, 
				onError: (e) => {
				  console.log('Error while open video ad:', e);
				}
			}
		})
	},

SaveExtern: function (date){
		var dateString = UTF8ToString(date);
		var myobj = JSON.parse(dateString);
		console.log(myobj);
		player.setData(myobj);
	},

LoadExtern: function (){
		player.getData().then(_date => {
			const myJSON = JSON.stringify(_date);
			console.log(myJSON);
			gameInstance.SendMessage("PlayerOptions", "Load", myJSON);
		});
	},	
	
SetToLeaderboardExtern: function (value){
		ysdk.getLeaderboards()
		.then(lb => {			
			lb.setLeaderboardScore('bestLevel', value);			
		});
	},	
	
GetLanguageExtern: function (){
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},
});