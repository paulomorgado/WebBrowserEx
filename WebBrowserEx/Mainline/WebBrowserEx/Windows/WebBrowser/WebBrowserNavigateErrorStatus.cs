//-----------------------------------------------------------------------
// <copyright file="WebBrowserNavigateErrorStatus.cs" company="Paulo Morgado">
// Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <summary>
// The possible errors returned by the StatusCode parameter of the NavigateError event.
// </summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.Windows.WebBrowser
{
    using System;

    /// <summary>
    /// The possible errors returned by the <see cref="NavigateErrorEventArgs.StatusCode"/> parameter of the <see cref="WebBrowserControl.NavigateError"/> event.
    /// </summary>
    public enum WebBrowserNavigateErrorStatus : int
    {
        /// <summary>
        /// Invalid syntax.
        /// </summary>
        /// <remarks>HTTP_STATUS_BAD_REQUEST</remarks>
        HttpStatusBadRequest = 400,

        /// <summary>
        /// Access denied.
        /// </summary>
        /// <remarks>HTTP_STATUS_DENIED</remarks>
        HttpStatusDenied = 401,

        /// <summary>
        /// Payment required.
        /// </summary>
        /// <remarks>HTTP_STATUS_PAYMENT_REQ</remarks>
        HttpStatusPaymentRequired = 402,

        /// <summary>
        /// Request forbidden.
        /// </summary>
        /// <remarks>HTTP_STATUS_FORBIDDEN</remarks>
        HttpStatusForbidden = 403,

        /// <summary>
        /// Object not found.
        /// </summary>
        /// <remarks>HTTP_STATUS_NOT_FOUND</remarks>
        HttpStatusNotFound = 404,

        /// <summary>
        /// Method is not allowed.
        /// </summary>
        /// <remarks>HTTP_STATUS_BAD_METHOD</remarks>
        HttpStatusBadMethod = 405,

        /// <summary>
        /// No response acceptable to client found.
        /// </summary>
        /// <remarks>HTTP_STATUS_NONE_ACCEPTABLE</remarks>
        HttpStatusNoneAcceptable = 406,

        /// <summary>
        /// Proxy authentication required.
        /// </summary>
        /// <remarks>HTTP_STATUS_PROXY_AUTH_REQ</remarks>
        HttpStatusProxyAuthenticationRequired = 407,

        /// <summary>
        /// Server timed out waiting for request.
        /// </summary>
        /// <remarks>HTTP_STATUS_REQUEST_TIMEOUT</remarks>
        HttpStatusRequestTimeout = 408,

        /// <summary>
        /// User should resubmit with more info.
        /// </summary>
        /// <remarks>HTTP_STATUS_CONFLICT</remarks>
        HttpStatusConflict = 409,

        /// <summary>
        /// Resource is no longer available.
        /// </summary>
        /// <remarks>HTTP_STATUS_GONE</remarks>
        HttpStatusGone = 410,

        /// <summary>
        /// Server refused to accept request without a length.
        /// </summary>
        /// <remarks>HTTP_STATUS_LENGTH_REQUIRED</remarks>
        HttpStatusLengthRequired = 411,

        /// <summary>
        /// Precondition given in request failed.
        /// </summary>
        /// <remarks>HTTP_STATUS_PRECOND_FAILED</remarks>
        HttpStatusPrecondFailed = 412,

        /// <summary>
        /// Request entity was too large.
        /// </summary>
        /// <remarks>HTTP_STATUS_REQUEST_TOO_LARGE</remarks>
        HttpStatusRequestTooLarge = 413,

        /// <summary>
        /// Request Uniform Resource Identifier = unchecked((int)(URI) too long.
        /// </summary>
        /// <remarks>HTTP_STATUS_URI_TOO_LONG</remarks>
        HttpStatusUriTooLong = 414,

        /// <summary>
        /// Unsupported media type.
        /// </summary>
        /// <remarks>HTTP_STATUS_UNSUPPORTED_MEDIA</remarks>
        HttpStatusUnsupportedMedia = 415,

        /// <summary>
        /// Retry after doing the appropriate action.
        /// </summary>
        /// <remarks>HTTP_STATUS_RETRY_WITH</remarks>
        HttpStatusRetryWith = 449,

        /// <summary>
        /// Internal server error.
        /// </summary>
        /// <remarks>HTTP_STATUS_SERVER_ERROR</remarks>
        HttpStatusServerError = 500,

        /// <summary>
        /// Server does not support the functionality required to fulfill the request.
        /// </summary>
        /// <remarks>HTTP_STATUS_NOT_SUPPORTED</remarks>
        HttpStatusNotSupported = 501,

        /// <summary>
        /// Error response received from gateway.
        /// </summary>
        /// <remarks>HTTP_STATUS_BAD_GATEWAY</remarks>
        HttpStatusBadGateway = 502,

        /// <summary>
        /// Temporarily overloaded.
        /// </summary>
        /// <remarks>HTTP_STATUS_SERVICE_UNAVAIL</remarks>
        HttpStatusServiceUnavail = 503,

        /// <summary>
        /// Timed out waiting for gateway.
        /// </summary>
        /// <remarks>HTTP_STATUS_GATEWAY_TIMEOUT</remarks>
        HttpStatusGatewayTimeout = 504,

        /// <summary>
        /// HTTP version not supported.
        /// </summary>
        /// <remarks>HTTP_STATUS_VERSION_NOT_SUP</remarks>
        HttpStatusVersionNotSupported = 505,

        /// <summary>
        /// URL string is not valid.
        /// </summary>
        /// <remarks>INET_E_INVALID_URL</remarks>
        InetErrorInvalidUrl = unchecked((int)(0x800C0002)),

        /// <summary>
        /// No session found.
        /// </summary>
        /// <remarks>INET_E_NO_SESSION</remarks>
        InetErrorNoSession = unchecked((int)(0x800C0003)),

        /// <summary>
        /// Unable to connect to server.
        /// </summary>
        /// <remarks>INET_E_CANNOT_CONNECT</remarks>
        InetErrorCannotConnect = unchecked((int)(0x800C0004)),

        /// <summary>
        /// Requested resource is not found.
        /// </summary>
        /// <remarks>INET_E_RESOURCE_NOT_FOUND</remarks>
        InetErrorResourceNotFound = unchecked((int)(0x800C0005)),

        /// <summary>
        /// Requested object is not found.
        /// </summary>
        /// <remarks>INET_E_OBJECT_NOT_FOUND</remarks>
        InetErrorObjectNotFound = unchecked((int)(0x800C0006)),

        /// <summary>
        /// Requested data is not available.
        /// </summary>
        /// <remarks>INET_E_DATA_NOT_AVAILABLE</remarks>
        InetErrorDataNotAvailable = unchecked((int)(0x800C0007)),

        /// <summary>
        /// Failure occurred during download.
        /// </summary>
        /// <remarks>INET_E_DOWNLOAD_FAILURE</remarks>
        InetErrorDownloadFailure = unchecked((int)(0x800C0008)),

        /// <summary>
        /// Requested navigation requires authentication.
        /// </summary>
        /// <remarks>INET_E_AUTHENTICATION_REQUIRED</remarks>
        InetErrorAuthenticationRequired = unchecked((int)(0x800C0009)),

        /// <summary>
        /// Required media not available or valid.
        /// </summary>
        /// <remarks>INET_E_NO_VALID_MEDIA</remarks>
        InetErrorNoValidMedia = unchecked((int)(0x800C000A)),

        /// <summary>
        /// Connection timed out.
        /// </summary>
        /// <remarks>INET_E_CONNECTION_TIMEOUT</remarks>
        InetErrorConnectionTimeout = unchecked((int)(0x800C000B)),

        /// <summary>
        /// Request is invalid.
        /// </summary>
        /// <remarks>INET_E_INVALID_REQUEST</remarks>
        InetErrorInvalidRequest = unchecked((int)(0x800C000C)),

        /// <summary>
        /// Protocol is not recognized.
        /// </summary>
        /// <remarks>INET_E_UNKNOWN_PROTOCOL</remarks>
        InetErrorUnknownProtocol = unchecked((int)(0x800C000D)),

        /// <summary>
        /// Navigation request has encountered a security issue.
        /// </summary>
        /// <remarks>INET_E_SECURITY_PROBLEM</remarks>
        InetErrorSecurityProblem = unchecked((int)(0x800C000E)),

        /// <summary>
        /// Unable to load data from the server.
        /// </summary>
        /// <remarks>INET_E_CANNOT_LOAD_DATA</remarks>
        InetErrorCannotLoadData = unchecked((int)(0x800C000F)),

        /// <summary>
        /// Unable to create an instance of the object.
        /// </summary>
        /// <remarks>INET_E_CANNOT_INSTANTIATE_OBJECT</remarks>
        InetErrorCannotInstantiateObject = unchecked((int)(0x800C0010)),

        /// <summary>
        /// Attempt to redirect the navigation failed.
        /// </summary>
        /// <remarks>INET_E_REDIRECT_FAILED</remarks>
        InetErrorRedirectFailed = unchecked((int)(0x800C0014)),

        /// <summary>
        /// Navigation redirected to a directory.
        /// </summary>
        /// <remarks>INET_E_REDIRECT_TO_DIR</remarks>
        InetErrorRedirectToDir = unchecked((int)(0x800C0015)),

        /// <summary>
        /// Unable to lock request with the server.
        /// </summary>
        /// <remarks>INET_E_CANNOT_LOCK_REQUEST</remarks>
        InetErrorCannotLockRequest = unchecked((int)(0x800C0016)),

        /// <summary>
        /// Reissue request with extended binding.
        /// </summary>
        /// <remarks>INET_E_USE_EXTEND_BINDING</remarks>
        InetErrorUseExtendBinding = unchecked((int)(0x800C0017)),

        /// <summary>
        /// Binding is terminated.
        /// </summary>
        /// <remarks>INET_E_TERMINATED_BIND</remarks>
        InetErrorBindingTerminated = unchecked((int)(0x800C0018)),

        /// <summary>
        /// Permission to download is declined.
        /// </summary>
        /// <remarks>INET_E_CODE_DOWNLOAD_DECLINED</remarks>
        InetErrorCodeDownloadDeclined = unchecked((int)(0x800C0100)),

        /// <summary>
        /// Result is dispatched.
        /// </summary>
        /// <remarks>INET_E_RESULT_DISPATCHED</remarks>
        InetErrorResultDispatched = unchecked((int)(0x800C0200)),

        /// <summary>
        /// Cannot replace a protected System File Protection = unchecked((int)(SFP) file.
        /// </summary>
        /// <remarks>INET_E_CANNOT_REPLACE_SFP_FILE</remarks>
        InetErrorCannotReplaceSystemFileProtectionFile = unchecked((int)(0x800C0300))
    }
}
