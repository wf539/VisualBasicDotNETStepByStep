Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports MyMovieCollection1.AmazonServiceSDK

''' <summary>
''' Provides simple search functionality using Amazon.com Web Services v4.0
''' </summary>
''' <remarks>
''' Wrapper over the AmazonServiceSDK. See http://www.amazon.com/aws/ 
''' for more information about the service and SDK.  
''' </remarks>
Public Class SimpleAmazonWS

    'flag - if True virtually all HTML markup from the Web service will be filtered out
    Private Const HTMLFilteringEnabled As Boolean = True

    ''' <summary>
    ''' Search for DVDs by Keywords
    ''' </summary>
    ''' <param name="searchString">dvd keyword to search for, e.g. name, actor, or UPC</param>
    ''' <returns>BindingList of DVD search results</returns>
    ''' <remarks>Several search criterial values can be altered in the Settings designer</remarks>
    Public Function SearchDVDs(ByVal searchString As String) As BindingList(Of DVD)
        'bindinglist of DVD objects to store and return results
        Dim searchResults As BindingList(Of DVD)

        'objects needed to define search and search criteria
        Dim itemSearchRequest As New ItemSearchRequest
        Dim itemSearch As New ItemSearch

        'initialize objects
        With itemSearchRequest
            'set the search keyword(s)
            .Keywords = searchString

            'set the size of the response, e.g. "Medium"
            .ResponseGroup = New String() {"Medium"}

            'set the SearchIndex or search mode, e.g. "DVD"
            .SearchIndex = My.Settings.AmazonSearchMode
        End With

        With itemSearch
            'set the Amazon.com SubscriptionId, or use the default for this application
            .SubscriptionId = My.Settings.AmazonSubscriptionId

            .Request = New ItemSearchRequest() {itemSearchRequest}
        End With

        'objects to store the response of the Web service
        Dim amazonResponse As ItemSearchResponse = Nothing
        Dim amazonItems As Item() = Nothing

        'bind the Web service proxy to the appropriate service end-point URL for the current locale
        My.WebServices.AWSECommerceService.Url = Me.GetLocUrl

        'call the Web service and assign the response
        amazonResponse = My.WebServices.AWSECommerceService.ItemSearch(itemSearch)

        'access the array of returned items is the response is not Nothing
        If amazonResponse IsNot Nothing Then
            amazonItems = amazonResponse.Items(0).Item
        Else
            'else the array of items is Nothing or empty
        End If

        'convert Amazon Items to generic collection of DVDs
        searchResults = GetListOfDVDs(amazonItems)

        Return searchResults
    End Function

    ''' <summary>
    ''' Looks up refreshed data about a particular DVD based on a UPC string argument.  
    ''' </summary>
    ''' <param name="upc">UPC code of the DVD to look up</param>
    ''' <returns>First DVD object found with this matching ASIN or UPC, or nothing if none were found</returns>
    ''' <remarks></remarks>
    Public Function RefreshDVDByUPC(ByVal upc As String) As DVD
        'object to store refreshed DVD result; initialized to empty DVD
        Dim refreshedDVD As New DVD

        'objects that store all lookup results
        Dim foundDVDs As BindingList(Of DVD)
        Dim foundItems As Item()

        'lookup item by ASIN or UPC
        foundItems = Me.LookupItemByASIN(upc)

        'convert to List of DVD objects
        foundDVDs = Me.GetListOfDVDs(foundItems)

        'return the first item
        If foundDVDs.Count > 0 Then
            refreshedDVD = foundDVDs(0)
        End If

        Return refreshedDVD
    End Function

    ''' <summary>
    ''' Looks up particular Amazon Item based on an ASIN or UPC string argument.  
    ''' </summary>
    ''' <param name="asinString">ASIN code of the DVD to look up</param>
    ''' <returns>First DVD object found with this matching ASIN or UPC, or nothing if none were found</returns>
    ''' <remarks>Used by RefreshDVDByUPC method.  </remarks>
    Private Function LookupItemByASIN(ByVal asinString As String) As Item()
        'object that stores Items from lookup
        Dim amazonItems As Item() = Nothing

        Dim itemLookup As New ItemLookup
        Dim request As New ItemLookupRequest

        With request
            .ResponseGroup = New String() { _
            "Medium"}

            .ItemId = New String() {asinString}
            .IdType = ItemLookupRequestIdType.[ASIN]
            .IdTypeSpecified = True
        End With

        With itemLookup
            'set the SearchIndex or search mode, e.g. "DVD"
            itemLookup.SubscriptionId = My.Settings.AmazonSubscriptionId

            'set request 
            itemLookup.Request = New ItemLookupRequest() {request}
        End With

        'object to store the response of the Web service
        Dim amazonResponse As ItemLookupResponse = Nothing

        'bind the Web service proxy to the appropriate service end-point URL for the current locale
        My.WebServices.AWSECommerceService.Url = Me.GetLocUrl

        'call the Web service and assign the response
        amazonResponse = My.WebServices.AWSECommerceService.ItemLookup(itemLookup)

        'access the array of returned items is the response is not Nothing
        If amazonResponse IsNot Nothing Then
            If (amazonResponse.Items IsNot Nothing) AndAlso (amazonResponse.Items.Length > 0) Then
                amazonItems = amazonResponse.Items(0).Item
            End If
        Else
            'else the array of items is Nothing or empty
        End If

        Return amazonItems
    End Function

    ''' <summary>
    ''' Utility function that converts the Amazon running time field to a string
    ''' </summary>
    Private Function AmazonItemRunningTimeToString(ByVal amazonItem As Item) As String
        Dim runningTime As String = ""
        With amazonItem
            With .ItemAttributes
                If .RunningTime IsNot Nothing Then
                    runningTime = .RunningTime.Value
                End If

            End With
        End With
        Return runningTime
    End Function

    ''' <summary>
    ''' Utility function that converts the Amazon editorial review field to a string
    ''' </summary>
    ''' <remarks>Used to provide a description for an item</remarks>
    Private Function AmazonItemDescriptionToString(ByVal amazonItem As Item) As String
        Dim description As String = ""
        Dim editorialReviews As EditorialReview() = amazonItem.EditorialReviews
        If (editorialReviews IsNot Nothing) AndAlso (editorialReviews.Length > 0) Then
            If HTMLFilteringEnabled = True Then
                description = Me.FilterHTMLText(editorialReviews(0).Content)
            Else
                description = editorialReviews(0).Content
            End If
        End If
        Return description
    End Function

    ''' <summary>
    ''' Utility function that converts the Amazon ImageURL to a URL string
    ''' </summary>
    ''' <remarks>Used to load the item image</remarks>
    Private Function AmazonItemLargeImageURLToString(ByVal amazonItem As Item) As String
        Dim largeImageUrl As String = ""
        With amazonItem
            If .LargeImage IsNot Nothing Then
                largeImageUrl = .LargeImage.URL
            End If
        End With
        Return largeImageUrl
    End Function

    ''' <summary>
    ''' Utility function that returns ASIN string from an Item
    ''' </summary>
    ''' <remarks>Used to look up DVD objects by ASIN or UPC</remarks>
    Private Function AmazonASINToString(ByVal amazonItem As Item) As String
        Dim asinString As String = ""

        If (amazonItem IsNot Nothing) AndAlso (amazonItem.ASIN.Length > 0) Then
            asinString = amazonItem.ASIN.ToString
        End If

        Return asinString
    End Function

    ''' <summary>
    ''' Utility function that converts Amazon Item array objects to a bindinglist of DVD objects
    ''' </summary>
    ''' <returns>BindingList of DVD objects, or an empty list if the array is nothing</returns>
    Private Function GetListOfDVDs(ByVal amazonItems As Item()) As BindingList(Of DVD)
        Dim dvds As New BindingList(Of DVD)
        Dim dvd As DVD

        If amazonItems IsNot Nothing Then

            For Each amazonItem As Item In amazonItems

                With amazonItem

                    dvd = New DVD(.ItemAttributes.Title, _
                                       Me.AmazonASINToString(amazonItem), _
                                        Me.AmazonItemDescriptionToString(amazonItem), _
                                       .ItemAttributes.Actor, _
                                       .ItemAttributes.Director, _
                                       .ItemAttributes.AudienceRating, _
                                        Me.AmazonItemRunningTimeToString(amazonItem), _
                                        Me.AmazonDateFormatToString(.ItemAttributes.TheatricalReleaseDate), _
                                        .DetailPageURL, _
                                        Me.AmazonItemLargeImageURLToString(amazonItem))


                End With
                dvds.Add(dvd)
            Next
        End If
        Return dvds
    End Function

    ''' <summary>
    ''' Utility function that looks up the appropriate localized service end-point 
    ''' URL based on AmazonLocale setting
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Used by SimpleAmazonWS to change the locale of the data results.  
    ''' Supports AmazonLocale setting values {"EN", "UK", "DE", "JP", "FR", "CA", "US"}
    ''' </remarks>
    Private Function GetLocUrl() As String
        Dim locUrl As String = ""
        Dim localeString As String = UCase(My.Settings.AmazonLocale)

        Select Case localeString
            Case "EN"
                locUrl = My.Settings.AmazonUrlEN
            Case "UK"
                locUrl = My.Settings.AmazonUrlUK
            Case "DE"
                locUrl = My.Settings.AmazonUrlDE
            Case "JP"
                locUrl = My.Settings.AmazonUrlJP
            Case "FR"
                locUrl = My.Settings.AmazonUrlFR
            Case "CA"
                locUrl = My.Settings.AmazonUrlCA
            Case "US"
                locUrl = My.Settings.AmazonUrlEN
            Case Else
                locUrl = My.Settings.AmazonUrlEN
        End Select

        Return locUrl
    End Function

    ''' <summary>
    ''' Utility function to return Amazon's custom date/timestamp formats into a .NET Date type
    ''' </summary>
    ''' <param name="amazonDate">Date string returned by Amazon.com's ProductInfo type</param>
    ''' <returns>Date type converted from custom string, or empty string if parameter is nothing</returns>
    ''' <remarks></remarks>
    Private Function AmazonDateFormatToString(ByVal amazonDate As String) As String
        ' Format to handle Amazon's convention for date strings; 0 means not set
        Dim expectedFormats As String() = {"d", "yyyy", "yyyy-mm", "yyyymmdd", "yyyy0000", "yyyymm00", "yyyy00dd", "yyyy-mm-dd"}
        Dim myDate As Date
        If amazonDate IsNot Nothing Then
            myDate = DateTime.ParseExact(amazonDate, _
                                expectedFormats, _
                                My.Application.Culture, _
                                Globalization.DateTimeStyles.AllowWhiteSpaces)
        Else
            Return ""
        End If

        Return myDate.ToString("yyyy")
    End Function

    ''' <summary>
    ''' Utility function that strips HTML tags and whitespace from the input string.
    ''' </summary>
    ''' <param name="htmlText"></param>
    ''' <remarks>Used by GetListOfDVDs method. </remarks>
    Private Function FilterHTMLText(ByVal htmlText As String) As String
        Dim filteredText As String = ""

        If htmlText IsNot Nothing Then
            filteredText = htmlText

            'remove HTML tags using a regular expression
            filteredText = Regex.Replace(filteredText, "(<[^>]+>)", "")

            'remove whitespace characters using a regular expression
            filteredText = Regex.Replace(filteredText, "&(nbsp|#160);", "")

            'optional: format out additional characters 
            '...
        End If

        Return filteredText
    End Function
End Class
