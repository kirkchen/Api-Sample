/// <reference path="..\typings\jquery\jquery.d.ts" />
/// <reference path="..\typings\knockout\knockout.d.ts" />

module ApiSample {
    export class UtilService {
        GetTimeStamp() {
            var dfd = $.Deferred();

            $.ajax({
                url: '/Util/GetTimeStamp',
                type: 'GET',
                contentType: 'application/json',
                success: (result) => {
                    dfd.resolve(result);
                },
                error: (ex) => {
                    dfd.reject(ex);
                }
            });

            return dfd.promise();
        }

        GetSignature(key: string, saltkey: string, timestamp: any, data: string) {
            var dfd = $.Deferred();
            
            $.ajax({
                url: '/Util/GetSignature', 
                type: 'GET',
                contentType: 'application/json',
                data: { key: key, saltkey: saltkey, timestamp: timestamp, data: data },
                success: (result) => {
                    dfd.resolve(result);
                },
                error: (ex) => {
                    dfd.reject(ex);
                }
            });

            return dfd.promise();
        }
    }
    export class UtilHelper {
        service: UtilService;

        url: KnockoutObservable<string>;

        key: KnockoutObservable<string>;

        saltkey: KnockoutObservable<string>;

        token: KnockoutObservable<string>;

        data: KnockoutObservable<string>;

        result: KnockoutObservable<string>;

        constructor() {
            //this.url = ko.observable('/Product/GetProductByCategory/3');
            this.url = ko.observable('/Product/Create');
            this.key = ko.observable('1111');
            this.saltkey = ko.observable('1111');
            this.token = ko.observable('123456');
            //this.data = ko.observable('{}');
            this.data = ko.observable("{'Name':'Test','Price':200,'Cost':200,'Introduction':'Test Description','StartListingAt':'2013 - 10 - 09T10:00:00','FinishListingAt':'2014 - 10 - 09T10:00:00','StartSellAt':'2013 - 10 - 09T10:00:00','FinishSellAt':'2014 - 10 - 09T10:00:00','CategoryId':0,'Gifts':'Gift1:Gift1Desc; Gift2:Gift2Desc'}");
            this.result = ko.observable();

            this.service = new UtilService();

            this.Query = () => {
                this.service.GetTimeStamp()
                    .done((timeStamp) => {
                        this.service.GetSignature(this.key(), this.saltkey(), timeStamp, this.data())
                            .done((signature) => {
                                $.ajax({
                                    url: this.url(),
                                    type: 'POST',
                                    contentType: 'application/json',
                                    data: ko.toJSON({ token: this.token(), timestamp: timeStamp, signature: signature, data: this.data() }),
                                    success: (result) => {                                        
                                        this.result('<pre>' + JSON.stringify(ko.toJS(result), null, '  ') + '</pre>');
                                    },
                                    error: (ex) => {
                                        this.result('<pre>' + JSON.stringify(JSON.parse(ex.responseText), null, '  ') + '</pre>');
                                    }
                                });
                            });
                    });
            }
        }

        Query: Function;
    }
}

var helper = new ApiSample.UtilHelper();
ko.applyBindings(helper);
