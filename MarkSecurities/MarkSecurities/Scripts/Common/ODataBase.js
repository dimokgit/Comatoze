var oDataClient = {
    errorFunction: {},
    successFunction: {},
    self : null,
    init: function (successFunction, errorFunction) {
        this.successFunction = successFunction;
        this.errorFunction = errorFunction;
        self = this;
    },
    invoke: function (url, type, data, headerPair) {
        $.ajax({
            type: type,
            contentType: "application/json; charset=utf-8",
            datatype: "json",            
            url: url,
            data: (!(data == null || data === 'undefined') ? data : null),
            beforeSend: function (XMLHttpRequest) {
                if (headerPair == null || headerPair === 'undefined')
                {
                    //Specifying this header ensures that the results will be returned as JSON.
                    XMLHttpRequest.setRequestHeader("Accept", "application/json");
                }
                else {
                    XMLHttpRequest.setRequestHeader(headerPair.key, headerPair.value);
                }                
            },
            success: function (data, textStatus, XmlHttpRequest) {
                self.successFunction(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var bundleError = new Object();
                bundleError.XMLHttpRequest = XMLHttpRequest;
                bundleError.textStatus = textStatus;
                bundleError.errorThrown = errorThrown;
                self.errorFunction(bundleError);
            }
        });
    }
};