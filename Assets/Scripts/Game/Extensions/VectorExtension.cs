using System;
using UnityEngine;

public static class VectorExtension 
{
    public static Vector2 ToVector2(this Vector3 vec3)
    {
        return vec3;
    }

    public static Vector3 ToVector3(this Vector2 vec2)
    {
        return vec2;
    }

    public static Vector3 Add(this Vector3 thisVector, Vector2 vec2)
    {
        return thisVector + vec2.ToVector3();
    }

    public static Vector2 Add(this Vector2 thisVector, Vector3 vec3)
    {
        return thisVector + vec3.ToVector2();
    }
    
    public static Vector3 Sub(this Vector3 thisVector, Vector2 vec2)
    {
        return thisVector - vec2.ToVector3();
    }

    public static Vector2 Sub(this Vector2 thisVector, Vector3 vec3)
    {
        return thisVector - vec3.ToVector2();
    }

    public static Vector3 Translate(this Vector3 vector, float deltaX, float deltaY, float deltaZ)
    {
        vector.x += deltaX;
        vector.y += deltaY;
        vector.z += deltaZ;
        return vector;
    }
    
    public static Vector3 Translate(this Vector3 vector, Vector3 offset)
    {
        vector.x += offset.x;
        vector.y += offset.y;
        vector.z += offset.z;
        return vector;
    }
    
    public static Vector3 Translate(this Vector3 vector, Vector2 offset)
    {
        vector.x += offset.x;
        vector.y += offset.y;
        return vector;
    }
    
    public static Vector2 Translate(this Vector2 vector, float deltaX, float deltaY)
    {
        vector.x += deltaX;
        vector.y += deltaY;
        return vector;
    }

    public static Vector2 Translate(this Vector2 vector, Vector2 offset)
    {
        vector.x += offset.x;
        vector.y += offset.y;
        return vector;
    }

    public static Vector3 SetX(this Vector3 vector, float x)
    {
        vector.x = x;
        return vector;
    }
    
    public static Vector3 SetY(this Vector3 vector, float y)
    {
        vector.y = y;
        return vector;
    }

    public static Vector3 SetZ(this Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }

    public static Vector2 SetX(this Vector2 vector, float x)
    {
        vector.x = x;
        return vector;
    }
    
    public static Vector2 SetY(this Vector2 vector, float y)
    {
        vector.y = y;
        return vector;
    }

    public static Vector3 FlipX(this Vector3 vector)
    {
        vector.x = -vector.x;
        return vector;
    }


    public static Vector3 FlipY(this Vector3 vector)
    {
        vector.y = -vector.y;
        return vector;
    }
    
    public static Vector3 FlipZ(this Vector3 vector)
    {
        vector.z = -vector.z;
        return vector;
    }
    
    public static Vector2 FlipX(this Vector2 vector)
    {
        vector.x = -vector.x;
        return vector;
    }
    
    public static Vector2 FlipY(this Vector2 vector)
    {
        vector.y = -vector.y;
        return vector;
    }
    
    public static Vector3 Translate(this Vector2 vector, float deltaX, float deltaY, float deltaZ)
    {
        return new Vector3(vector.x + deltaX, vector.y + deltaY, deltaZ);
    }
    
    public static bool CompareTo(this Vector3 a, Vector3 b, float epsilon = float.Epsilon)
    {
        return Math.Abs(a.x - b.x) < epsilon && Math.Abs(a.y - b.y) < epsilon && Math.Abs(a.z - b.z) < epsilon;
    }

    public static bool CompareTo(this Vector2 a, Vector2 b, float epsilon = float.Epsilon)
    {
        return Math.Abs(a.x - b.x) < epsilon && Math.Abs(a.y - b.y) < epsilon;
    }

    public static Vector2 Clamp(this Vector2 v, float a, float b)
    {
        v.x = Mathf.Clamp(v.x, a, b);
        v.y = Mathf.Clamp(v.y, a, b);

        return v;
    }
    
    public static Vector3 Clamp(this Vector3 v, float a, float b)
    {
        v.x = Mathf.Clamp(v.x, a, b);
        v.y = Mathf.Clamp(v.x, a, b);
        v.z = Mathf.Clamp(v.x, a, b);

        return v;
    }
    
    public static Vector3 GetDirectionToTarget(this Vector3 position, Vector3 target)
    {
        return target - position;
    }
}