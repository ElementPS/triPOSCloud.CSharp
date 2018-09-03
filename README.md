# triPOSCloud.CSharp

* <a href="https://developer.vantiv.com/?utm_campaign=githubcta&utm_medium=hyperlink&utm_source=github&utm_content=gotquestions">Got questions? Connect with our experts on Worldpay ONE.</a>
* <a href="https://developer.vantiv.com/?utm_campaign=githubcta&utm_medium=hyperlink&utm_source=github&utm_content=codingforcommerce">Are you coding for commerce? Connect with our experts on Worldpay ONE.</a>
* Questions?  certification@elementps.com
* **Feature request?** Open an issue.
* Feel like **contributing**?  Submit a pull request.


## Overview

This repository demonstrates an integration to the triPOS Cloud product using c#.  The code was compiled and tested using Microsoft Visual Studio Express 2015 for Windows Desktop.  The application itself allows a user to perform the typical functions necessary to pair a lane with triPOS Cloud, run a sale transaction, and integrate to Store Card.

## Prerequisites

Please contact your Integration Analyst for any questions about the below prerequisites.

* Create Express test account: http://www.elementps.com/Resources/Create-a-Test-Account
* Request EMV simulator credentials from your Implementation Consultant
* Optionally install a hardware peripheral and obtain test cards (but you can be up and running without hardware for testing purposes)
* Currently triPOS is supported on Windows 7

## Documentation/Troubleshooting

* triPOS Cloud Integration Guide:  https://developer.vantiv.com/docs/DOC-2483
* triPOS Cloud Transaction API:  https://triposcert.vantiv.com/api/swagger-ui-bootstrap/
* triPOS Cloud Lane API:  https://triposcert.vantiv.com/cloudapi/swagger/ui/index#/

## Step 1: Pair a triPOS Cloud Lane

After plugging your triPOS Cloud device into power and obtaining a network connection (ethernet or wifi) your triPOS Cloud device should be showing an activation code.  Use the triPOS Cloud Lane API to POST a json request to:  https://triposcert.vantiv.com/cloudapi/v1/lanes/.

```
{
  "laneId": 1,
  "description": "test lane",
  "terminalId": "123",
  "activationCode": "1111111"
}

```

## Step 2: Send a Transaction to triPOS Cloud

Now that the device is paired to triPOS Cloud you should see the triPOS logo on the device.  The next step is to send a sale transaction.  Do this by using the triPOS Cloud transaction API to POST a json request to:  https://triposcert.vantiv.com/api/v1/sale.  Note:  use the same laneId as you used above, this laneId is the identifier for the device you paired above.  This is a simple json body and you will likely need to provide additional information for your use case.

```
{
	"laneId":"1",
	"transactionAmount":"6.22",
	"invokeManualEntry":false,
	"displayTransactionAmount":true,
	"configuration" : {
		"isManualEntryAllowed":"false",
		"promptForSignature":"UseThreshold",
		"thresholdAmount": "5.00"
	}
}

```

## Step 3: Receive response from triPOS Cloud

The response will be in a JSON format and you can leverage any JSON library to assist with parsing/serializing.  Only a portion of the response is include in the example below.

```
{
    "cashbackAmount": 0,
    "debitSurchargeAmount": 0,
    "approvedAmount": 0,
    "convenienceFeeAmount": 0,
    "subTotalAmount": 33.22,
    "tipAmount": 0,
    "emv": {
        "applicationIdentifier": "A0000000041010",
        "applicationLabel": "MasterCard",
        "applicationPreferredName": "MasterCard",
        "applicationTransactionCounter": "000C",
        "cryptogram": "AAC 25F0D6E108B41B11",
        "tags": [
            {
                "key": "50",
                "value": "4D617374657243617264"
        ],
        "issuerCodeTableIndex": "01",
        "pinBypassed": false
    },
    "fsaCard": "NotApplicable",
    "accountNumber": "************0681",
    "binValue": "541333",
    "cardHolderName": "Test Card 1",
    "cardLogo": "Mastercard",
    "currencyCode": "Usd",
    "entryMode": "ContactIcc",
    "expirationYear": "22",
    "expirationMonth": "12",
    "paymentType": "Credit",
    "pinVerified": true,
    "signature": {
        "statusCode": "SignatureNotRequiredByPaymentType"
    },
    "terminalId": "123",
    "totalAmount": 33.22,
    "isApproved": false,
}    

```


##### © 2018 Worldpay, LLC and/or its affiliates. All rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Element Payment Services, Inc., a Vantiv company, shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.
