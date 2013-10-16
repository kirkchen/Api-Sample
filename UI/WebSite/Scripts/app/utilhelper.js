/// <reference path="..\typings\jquery\jquery.d.ts" />
/// <reference path="..\typings\knockout\knockout.d.ts" />
var ApiSample;
(function (ApiSample) {
    var UtilService = (function () {
        function UtilService() {
        }
        UtilService.prototype.GetTimeStamp = function () {
            var dfd = $.Deferred();

            $.ajax({
                url: '/Util/GetTimeStamp',
                type: 'GET',
                contentType: 'application/json',
                success: function (result) {
                    dfd.resolve(result);
                },
                error: function (ex) {
                    dfd.reject(ex);
                }
            });

            return dfd.promise();
        };

        UtilService.prototype.GetSignature = function (key, saltkey, timestamp, data) {
            var dfd = $.Deferred();

            $.ajax({
                url: '/Util/GetSignature',
                type: 'GET',
                contentType: 'application/json',
                data: { key: key, saltkey: saltkey, timestamp: timestamp, data: data },
                success: function (result) {
                    dfd.resolve(result);
                },
                error: function (ex) {
                    dfd.reject(ex);
                }
            });

            return dfd.promise();
        };
        return UtilService;
    })();
    ApiSample.UtilService = UtilService;
    var UtilHelper = (function () {
        function UtilHelper() {
            var _this = this;
            this.url = ko.observable('/Product/GetProductByCategory/3');
            this.key = ko.observable('1111');
            this.saltkey = ko.observable('1111');
            this.token = ko.observable('123456');
            this.data = ko.observable('{}');
            this.result = ko.observable();

            this.service = new UtilService();

            this.Query = function () {
                _this.service.GetTimeStamp().done(function (timeStamp) {
                    _this.service.GetSignature(_this.key(), _this.saltkey(), timeStamp, _this.data()).done(function (signature) {
                        $.ajax({
                            url: _this.url(),
                            type: 'GET',
                            contentType: 'application/json',
                            data: { token: _this.token(), timestamp: timeStamp, signature: signature, data: _this.data() },
                            success: function (result) {
                                _this.result('<pre>' + JSON.stringify(ko.toJS(result), null, '  ') + '</pre>');
                            },
                            error: function (ex) {
                                console.log(ex);
                            }
                        });
                    });
                });
            };
        }
        return UtilHelper;
    })();
    ApiSample.UtilHelper = UtilHelper;
})(ApiSample || (ApiSample = {}));

var helper = new ApiSample.UtilHelper();
ko.applyBindings(helper);
//# sourceMappingURL=utilhelper.js.map
