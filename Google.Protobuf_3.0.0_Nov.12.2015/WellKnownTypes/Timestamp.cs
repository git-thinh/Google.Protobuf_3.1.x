// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/protobuf/timestamp.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.WellKnownTypes {

  namespace Proto {

    /// <summary>Holder for reflection information generated from google/protobuf/timestamp.proto</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class Timestamp {

      #region Descriptor
      /// <summary>File descriptor for google/protobuf/timestamp.proto</summary>
      public static pbr::FileDescriptor Descriptor {
        get { return descriptor; }
      }
      private static pbr::FileDescriptor descriptor;

      static Timestamp() {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            string.Concat(
              "Ch9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3RvEg9nb29nbGUucHJv",
              "dG9idWYiKwoJVGltZXN0YW1wEg8KB3NlY29uZHMYASABKAMSDQoFbmFub3MY",
              "AiABKAVCUQoTY29tLmdvb2dsZS5wcm90b2J1ZkIOVGltZXN0YW1wUHJvdG9Q",
              "AaABAaICA0dQQqoCHkdvb2dsZS5Qcm90b2J1Zi5XZWxsS25vd25UeXBlc2IG",
              "cHJvdG8z"));
        descriptor = pbr::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
            new pbr::FileDescriptor[] { },
            new pbr::GeneratedCodeInfo(null, new pbr::GeneratedCodeInfo[] {
              new pbr::GeneratedCodeInfo(typeof(global::Google.Protobuf.WellKnownTypes.Timestamp), new[]{ "Seconds", "Nanos" }, null, null, null)
            }));
      }
      #endregion

    }
  }
  #region Messages
  /// <summary>
  ///  A Timestamp represents a point in time independent of any time zone
  ///  or calendar, represented as seconds and fractions of seconds at
  ///  nanosecond resolution in UTC Epoch time. It is encoded using the
  ///  Proleptic Gregorian Calendar which extends the Gregorian calendar
  ///  backwards to year one. It is encoded assuming all minutes are 60
  ///  seconds long, i.e. leap seconds are "smeared" so that no leap second
  ///  table is needed for interpretation. Range is from
  ///  0001-01-01T00:00:00Z to 9999-12-31T23:59:59.999999999Z.
  ///  By restricting to that range, we ensure that we can convert to
  ///  and from  RFC 3339 date strings.
  ///  See [https://www.ietf.org/rfc/rfc3339.txt](https://www.ietf.org/rfc/rfc3339.txt).
  ///
  ///  Example 1: Compute Timestamp from POSIX `time()`.
  ///
  ///      Timestamp timestamp;
  ///      timestamp.set_seconds(time(NULL));
  ///      timestamp.set_nanos(0);
  ///
  ///  Example 2: Compute Timestamp from POSIX `gettimeofday()`.
  ///
  ///      struct timeval tv;
  ///      gettimeofday(&amp;tv, NULL);
  ///
  ///      Timestamp timestamp;
  ///      timestamp.set_seconds(tv.tv_sec);
  ///      timestamp.set_nanos(tv.tv_usec * 1000);
  ///
  ///  Example 3: Compute Timestamp from Win32 `GetSystemTimeAsFileTime()`.
  ///
  ///      FILETIME ft;
  ///      GetSystemTimeAsFileTime(&amp;ft);
  ///      UINT64 ticks = (((UINT64)ft.dwHighDateTime) &lt;&lt; 32) | ft.dwLowDateTime;
  ///
  ///      // A Windows tick is 100 nanoseconds. Windows epoch 1601-01-01T00:00:00Z
  ///      // is 11644473600 seconds before Unix epoch 1970-01-01T00:00:00Z.
  ///      Timestamp timestamp;
  ///      timestamp.set_seconds((INT64) ((ticks / 10000000) - 11644473600LL));
  ///      timestamp.set_nanos((INT32) ((ticks % 10000000) * 100));
  ///
  ///  Example 4: Compute Timestamp from Java `System.currentTimeMillis()`.
  ///
  ///      long millis = System.currentTimeMillis();
  ///
  ///      Timestamp timestamp = Timestamp.newBuilder().setSeconds(millis / 1000)
  ///          .setNanos((int) ((millis % 1000) * 1000000)).build();
  ///
  ///  Example 5: Compute Timestamp from current time in Python.
  ///
  ///      now = time.time()
  ///      seconds = int(now)
  ///      nanos = int((now - seconds) * 10**9)
  ///      timestamp = Timestamp(seconds=seconds, nanos=nanos)
  /// </summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class Timestamp : pb::IMessage<Timestamp> {
    private static readonly pb::MessageParser<Timestamp> _parser = new pb::MessageParser<Timestamp>(() => new Timestamp());
    public static pb::MessageParser<Timestamp> Parser { get { return _parser; } }

    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.WellKnownTypes.Proto.Timestamp.Descriptor.MessageTypes[0]; }
    }

    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    public Timestamp() {
      OnConstruction();
    }

    partial void OnConstruction();

    public Timestamp(Timestamp other) : this() {
      seconds_ = other.seconds_;
      nanos_ = other.nanos_;
    }

    public Timestamp Clone() {
      return new Timestamp(this);
    }

    /// <summary>Field number for the "seconds" field.</summary>
    public const int SecondsFieldNumber = 1;
    private long seconds_;
    /// <summary>
    ///  Represents seconds of UTC time since Unix epoch
    ///  1970-01-01T00:00:00Z. Must be from from 0001-01-01T00:00:00Z to
    ///  9999-12-31T23:59:59Z inclusive.
    /// </summary>
    public long Seconds {
      get { return seconds_; }
      set {
        seconds_ = value;
      }
    }

    /// <summary>Field number for the "nanos" field.</summary>
    public const int NanosFieldNumber = 2;
    private int nanos_;
    /// <summary>
    ///  Non-negative fractions of a second at nanosecond resolution. Negative
    ///  second values with fractions must still have non-negative nanos values
    ///  that count forward in time. Must be from 0 to 999,999,999
    ///  inclusive.
    /// </summary>
    public int Nanos {
      get { return nanos_; }
      set {
        nanos_ = value;
      }
    }

    public override bool Equals(object other) {
      return Equals(other as Timestamp);
    }

    public bool Equals(Timestamp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Seconds != other.Seconds) return false;
      if (Nanos != other.Nanos) return false;
      return true;
    }

    public override int GetHashCode() {
      int hash = 1;
      if (Seconds != 0L) hash ^= Seconds.GetHashCode();
      if (Nanos != 0) hash ^= Nanos.GetHashCode();
      return hash;
    }

    public override string ToString() {
      return pb::JsonFormatter.Default.Format(this);
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Seconds != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Seconds);
      }
      if (Nanos != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Nanos);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (Seconds != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Seconds);
      }
      if (Nanos != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Nanos);
      }
      return size;
    }

    public void MergeFrom(Timestamp other) {
      if (other == null) {
        return;
      }
      if (other.Seconds != 0L) {
        Seconds = other.Seconds;
      }
      if (other.Nanos != 0) {
        Nanos = other.Nanos;
      }
    }

    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Seconds = input.ReadInt64();
            break;
          }
          case 16: {
            Nanos = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code