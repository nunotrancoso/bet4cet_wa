function FBLoginConnectedData() {
	console.log('data');
	console.log(b4cgo.fbuid);
	console.log(b4cgo.fbuname);
	// if we have a FB uid and username, do a postback
	if ((b4cgo.fbuid != null) && (b4cgo.fbuid !== 'undefined') && (b4cgo.fbuname != null) && (b4cgo.fbuuname !== 'undefined')) {
		console.log('posting back : ' + b4cgo.fbuid + "_" + b4cgo.fbuname);
		__doPostBack("FBLOGIN", b4cgo.fbuid + "_" + b4cgo.fbuname);
	}
}
function FBLoginConnected()
{
	if ((b4cgo.fbuid != null) && (b4cgo.fbuid !== 'undefined')) {
		// we are logged in to FB, get user name
		console.log('logged in');
		FB.api('/me', { fields: 'name' }, function (response) {
			b4cgo.fbuname = response.name;
			console.log('fbuname = ' + b4cgo.fbuname.toString());
			FBLoginConnectedData();
		});
	}
}
function FBLogin()
{
	FB.getLoginStatus(function (response)
	{
		if (response.status === 'connected') {
			console.log('connected');
			b4cgo.fbuid = response.authResponse.userID;
			console.log('fbuid = ' + b4cgo.fbuid.toString());
			FBLoginConnected();
		} else {
			FB.login();
			FB.getLoginStatus(function (response) {
				if (response.status === 'connected') {
					console.log('connected');
					b4cgo.fbuid = response.authResponse.userID;
					console.log('fbuid = ' + b4cgo.fbuid.toString());
					FBLoginConnected();
				}
				else {
					b4cgo.fbuid = null; b4cgo.fbname = null;
					/* FB Error Handler here*/
				}
			});
		}
	});
}