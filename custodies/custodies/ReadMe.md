# 'طريقة أبو خلي

            //var xhr = new XMLHttpRequest();
            /*
             xhr.onreadystatechange = function () {
                if (this.readyState = 4) {
                console.log(this.responseText);
                }
            }
            xhr.open('post','https://testing3.alyaseenagri.com/AuthAPI/login')
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.send('username=AdminX&password=123456&duration=5&refresh-timeout=true')



            result:
            {
            "message":"تم تسجيل الدخول بنجاح.", 
            "type":"info", 
            "token":"7ac27faff564e3504d54d9b436d31bf3e3185be7eddb1132d2c889bd4ecea49d", 
            "user-id":"10158", 
            "token-type":"basic", 
            "expires-after":5, 
            "expires-on":"2021-08-30 15:45:11"
            }

            